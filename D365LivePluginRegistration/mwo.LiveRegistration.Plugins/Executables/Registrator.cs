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
            var subject = preImage == null ? target : preImage.Merge(target);

            if (!subject.GetAttributeValue<bool>("mwo_managed")) return;

            switch (ctx.MessageName.ToUpperInvariant())
            {
                case "CREATE":
                    DoCreate(trace, subject, registrationManager, svc);
                    break;
                case "UPDATE":
                    DoUpdate(trace, registrationManager, subject);
                    if (target.Contains("statecode"))
                        DoManageStage(trace, registrationManager, subject);
                    break;
                case "DELETE":
                    DoDelete(trace, subject, registrationManager);
                    break;
                default:
                    trace.Trace("Nothing to do for " + ctx.MessageName);
                    break;
            }
        }

        private static void DoDelete(ITracingService trace, Entity subject, IPluginStepRegistrationManager registrationManager)
        {
            registrationManager.Delete(subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
            trace.Trace("Deleted PluginStep: " + subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
        }

        private static void DoManageStage(ITracingService trace, IPluginStepRegistrationManager registrationManager, Entity subject)
        {
            var state = subject.GetAttributeValue<OptionSetValue>("statecode");
            if (state.Value == 0) //Active 
            {
                registrationManager.Activate(subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
                trace.Trace("Activated PluginStep: " + subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
            }
            else //Inactive
            {
                registrationManager.Deactivate(subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
                trace.Trace("Deactivated PluginStep: " + subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
            }
        }

        private void DoUpdate(ITracingService trace, IPluginStepRegistrationManager registrationManager, Entity subject)
        {
            registrationManager.Update(
                                subject.GetAttributeValue<Guid>("mwo_pluginstepid"),
                                subject.GetAttributeValue<string>("mwo_plugintypename"),
                                subject.GetAttributeValue<string>("mwo_sdkmessage"),
                                subject.GetAttributeValue<string>("mwo_primaryentity"),
                                subject.GetAttributeValue<string>("mwo_secondaryentity"),
                                subject.GetAttributeValue<string>("mwo_stepconfiguration"),
                                subject.GetAttributeValue<bool>("mwo_asynchronous"),
                                MapStage(subject.GetAttributeValue<OptionSetValue>("mwwo_pluginstepstage")),
                                subject.GetAttributeValue<string>("mwo_filteringattributes"),
                                subject.GetAttributeValue<string>("mwo_description"));

            trace.Trace("Updated PluginStep: " + subject.GetAttributeValue<Guid>("mwo_pluginstepid"));
        }

        private void DoCreate(ITracingService trace, Entity target, IPluginStepRegistrationManager registrationManager, IOrganizationService svc)
        {
            var res = registrationManager.Register(
                target.GetAttributeValue<string>("mwo_plugintypename"),
                target.GetAttributeValue<string>("mwo_sdkmessage"),
                target.GetAttributeValue<string>("mwo_primaryentity"),
                target.GetAttributeValue<string>("mwo_secondaryentity"),
                target.GetAttributeValue<string>("mwo_stepconfiguration"),
                target.GetAttributeValue<bool>("mwo_asynchronous"),
                MapStage(target.GetAttributeValue<OptionSetValue>("mwwo_pluginstepstage")),
                target.GetAttributeValue<string>("mwo_filteringattributes"),
                target.GetAttributeValue<string>("mwo_description"));

            trace.Trace("Created new PluginStep: " + res.ToString());
            target["mwo_pluginstepid"] = res;
            trace.Trace("Saved new PluginStep to Entity");
        }

        private static Stage MapStage(OptionSetValue optionSetValue)
        {
            return (Stage)(optionSetValue.Value - 122870000); // Values were created to match stages!
        }
    }
}
