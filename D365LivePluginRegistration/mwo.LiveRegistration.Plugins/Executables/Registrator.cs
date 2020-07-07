using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Extensions;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class Registrator : ICRMExecutable<Entity>
    {
        public void Execute(IOrganizationService svc, ITracingService trace, IPluginExecutionContext ctx, Entity target, Entity preImage = null)
        {
            IPluginStepRegistrationManager registrationManager = new PluginStepRegistrationManager(svc);
            IImageManager imageManager = new ImageManager(svc);
            var subject = preImage == null ? target : preImage.Merge(target);

            if (!subject.GetAttributeValue<bool>("mwo_managed")) return;

            var msg = ctx.MessageName.ToUpperInvariant();
            var pluginStepId = Guid.Empty;
            var hasId = subject.Contains("mwo_pluginstepid") && Guid.TryParse(subject.GetAttributeValue<string>("mwo_pluginstepid"), out pluginStepId);
            if (msg == "DELETE" && hasId)
            {
                DoDelete(trace, subject, registrationManager, imageManager, pluginStepId);
            }
            else if (msg == "UPDATE" && hasId)
            {
                DoUpdate(trace, registrationManager, imageManager, subject, pluginStepId);
                if (target.Contains("statecode"))
                    DoManageStage(trace, registrationManager, subject, pluginStepId);
            }
            else if ((msg == "UPDATE" || msg == "CREATE") && !hasId)
            {
                DoCreate(trace, subject, registrationManager, imageManager);
            }
            else
            {
                trace.Trace($"Nothing to do for {msg} and {(hasId ? "has Id" : "does not have Id")}");
            }
        }

        private static void DoDelete(ITracingService trace, Entity subject, IPluginStepRegistrationManager registrationManager, IImageManager imageManager, Guid pluginStepId)
        {
            subject["mwo_imagetype"] = new OptionSetValue(122870010); //Pass Image none, as we are going to delete.
            DoManageImage(trace, subject, imageManager, pluginStepId);

            registrationManager.Delete(pluginStepId);
            trace.Trace($"Deleted PluginStep: {pluginStepId}");
        }

        private static void DoManageStage(ITracingService trace, IPluginStepRegistrationManager registrationManager, Entity subject, Guid pluginStepId)
        {
            var state = subject.GetAttributeValue<OptionSetValue>("statecode");
            if (state.Value == 0) //Active 
            {
                registrationManager.Activate(pluginStepId);
                trace.Trace($"Activated PluginStep: {pluginStepId}");
            }
            else //Inactive
            {
                registrationManager.Deactivate(pluginStepId);
                trace.Trace($"Deactivated PluginStep: {pluginStepId}");
            }
        }

        private void DoUpdate(ITracingService trace, IPluginStepRegistrationManager registrationManager, IImageManager imageManager, Entity subject, Guid pluginStepId)
        {
            registrationManager.Update(
                                pluginStepId,
                                subject.GetAttributeValue<string>("mwo_plugintypename"),
                                subject.GetAttributeValue<string>("mwo_sdkmessage"),
                                subject.GetAttributeValue<string>("mwo_primaryentity"),
                                subject.GetAttributeValue<string>("mwo_secondaryentity"),
                                subject.GetAttributeValue<string>("mwo_stepconfiguration"),
                                subject.GetAttributeValue<bool>("mwo_asynchronous"),
                                MapStage(subject.GetAttributeValue<OptionSetValue>("mwo_pluginstepstage")),
                                subject.GetAttributeValue<string>("mwo_filteringattributes"),
                                subject.GetAttributeValue<string>("mwo_description"));

            trace.Trace($"Updated PluginStep: {pluginStepId}");

            DoManageImage(trace, subject, imageManager, pluginStepId);
        }

        private void DoCreate(ITracingService trace, Entity subject, IPluginStepRegistrationManager registrationManager, IImageManager imageManager)
        {
            var res = registrationManager.Register(
                subject.GetAttributeValue<string>("mwo_plugintypename"),
                subject.GetAttributeValue<string>("mwo_sdkmessage"),
                subject.GetAttributeValue<string>("mwo_primaryentity"),
                subject.GetAttributeValue<string>("mwo_secondaryentity"),
                subject.GetAttributeValue<string>("mwo_stepconfiguration"),
                subject.GetAttributeValue<bool>("mwo_asynchronous"),
                MapStage(subject.GetAttributeValue<OptionSetValue>("mwo_pluginstepstage")),
                subject.GetAttributeValue<string>("mwo_filteringattributes"),
                subject.GetAttributeValue<string>("mwo_description"));

            trace.Trace($"Created new PluginStep: {res}");
            subject["mwo_pluginstepid"] = res.ToString();

            DoManageImage(trace, subject, imageManager, res);
        }

        private static void DoManageImage(ITracingService trace, Entity subject, IImageManager imageManager, Guid pluginStepId)
        {
            if (subject.Contains("mwo_imagetype") && subject.GetAttributeValue<OptionSetValue>("mwo_imagetype").Value != 122870010)
            {
                imageManager.Upsert(MapImageType(subject.GetAttributeValue<OptionSetValue>("mwo_imagetype")), subject.GetAttributeValue<string>("mwo_imagename"), new EntityReference("sdkmessageprocessingstep", pluginStepId), subject.GetAttributeValue<string>("mwo_imageattributes"));
                trace.Trace($"Upserted image: {subject.GetAttributeValue<string>("mwo_imagename")}");
            }
            else
            {
                imageManager.Delete(new EntityReference("sdkmessageprocessingstep", pluginStepId));
                trace.Trace($"Deleted image: {subject.GetAttributeValue<string>("mwo_imagename")}");
            }
        }

        private static Stage MapStage(OptionSetValue optionSetValue)
        {
            return (Stage)(optionSetValue.Value - 122870000); // Values were created to match stages!
        }

        private static ImageType MapImageType(OptionSetValue optionSetValue)
        {
            return (ImageType)(optionSetValue.Value - 122870000); // Values were created to match types!
        }
    }
}
