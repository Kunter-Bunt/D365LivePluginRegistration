using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class Registrator : ICRMExecutable
    {
        private IPluginStepRegistrationManager StepManager { get; set; }
        private IImageManager ImageManager { get; set; }

        public Registrator(IOrganizationService service)
        {
            StepManager = new PluginStepRegistrationManager(service);
            ImageManager = new ImageManager(service);
        }

        public void Execute(IContext context)
        {
            if (!context.Subject.GetAttributeValue<bool>("mwo_managed")) return;

            var msg = context.PluginExecutionContext.MessageName.ToUpperInvariant();
            var pluginStepId = Guid.Empty;
            var hasId = context.Subject.Contains("mwo_pluginstepid") && Guid.TryParse(context.Subject.GetAttributeValue<string>("mwo_pluginstepid"), out pluginStepId);
            if (msg == "DELETE" && hasId)
            {
                DoDelete(context, pluginStepId);
            }
            else if (msg == "UPDATE" && hasId)
            {
                DoUpdate(context, pluginStepId);
                if (context.Target.Contains("statecode"))
                    DoManageStage(context, pluginStepId);
            }
            else if ((msg == "UPDATE" || msg == "CREATE") && !hasId)
            {
                DoCreate(context);
            }
            else
            {
                context.Tracer.Trace($"Nothing to do for {msg} and {(hasId ? "has Id" : "does not have Id")}");
            }
        }

        private void DoDelete(IContext context, Guid pluginStepId)
        {
            context.Subject["mwo_imagetype"] = new OptionSetValue(122870010); //Pass Image none, as we are going to delete.
            DoManageImage(context, pluginStepId);

            StepManager.Delete(pluginStepId);
            context.Tracer.Trace($"Deleted PluginStep: {pluginStepId}");
        }

        private void DoManageStage(IContext context, Guid pluginStepId)
        {
            var state = context.Subject.GetAttributeValue<OptionSetValue>("statecode");
            if (state.Value == 0) //Active 
            {
                StepManager.Activate(pluginStepId);
                context.Tracer.Trace($"Activated PluginStep: {pluginStepId}");
            }
            else //Inactive
            {
                StepManager.Deactivate(pluginStepId);
                context.Tracer.Trace($"Deactivated PluginStep: {pluginStepId}");
            }
        }

        private void DoUpdate(IContext context, Guid pluginStepId)
        {
            StepManager.Update(
                                pluginStepId,
                                context.Subject.GetAttributeValue<string>("mwo_plugintypename"),
                                context.Subject.GetAttributeValue<string>("mwo_sdkmessage"),
                                context.Subject.GetAttributeValue<string>("mwo_primaryentity"),
                                context.Subject.GetAttributeValue<string>("mwo_secondaryentity"),
                                context.Subject.GetAttributeValue<string>("mwo_stepconfiguration"),
                                context.Subject.GetAttributeValue<bool>("mwo_asynchronous"),
                                MapStage(context.Subject.GetAttributeValue<OptionSetValue>("mwo_pluginstepstage")),
                                context.Subject.GetAttributeValue<string>("mwo_filteringattributes"),
                                context.Subject.GetAttributeValue<string>("mwo_description"));

            context.Tracer.Trace($"Updated PluginStep: {pluginStepId}");

            DoManageImage(context, pluginStepId);
        }

        private void DoCreate(IContext context)
        {
            var res = StepManager.Register(
                context.Subject.GetAttributeValue<string>("mwo_plugintypename"),
                context.Subject.GetAttributeValue<string>("mwo_sdkmessage"),
                context.Subject.GetAttributeValue<string>("mwo_primaryentity"),
                context.Subject.GetAttributeValue<string>("mwo_secondaryentity"),
                context.Subject.GetAttributeValue<string>("mwo_stepconfiguration"),
                context.Subject.GetAttributeValue<bool>("mwo_asynchronous"),
                MapStage(context.Subject.GetAttributeValue<OptionSetValue>("mwo_pluginstepstage")),
                context.Subject.GetAttributeValue<string>("mwo_filteringattributes"),
                context.Subject.GetAttributeValue<string>("mwo_description"));

            context.Tracer.Trace($"Created new PluginStep: {res}");
            context.Subject["mwo_pluginstepid"] = res.ToString();

            DoManageImage(context, res);
        }

        private void DoManageImage(IContext context, Guid pluginStepId)
        {
            if (context.Subject.Contains("mwo_imagetype") && context.Subject.GetAttributeValue<OptionSetValue>("mwo_imagetype") != null && context.Subject.GetAttributeValue<OptionSetValue>("mwo_imagetype").Value != 122870010)
            {
                ImageManager.Upsert(MapImageType(context.Subject.GetAttributeValue<OptionSetValue>("mwo_imagetype")), context.Subject.GetAttributeValue<string>("mwo_imagename"), new EntityReference("sdkmessageprocessingstep", pluginStepId), context.Subject.GetAttributeValue<string>("mwo_imageattributes"));
                context.Tracer.Trace($"Upserted image: {context.Subject.GetAttributeValue<string>("mwo_imagename")}");
            }
            else
            {
                ImageManager.Delete(new EntityReference("sdkmessageprocessingstep", pluginStepId));
                context.Tracer.Trace($"Deleted image: {context.Subject.GetAttributeValue<string>("mwo_imagename")}");
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
