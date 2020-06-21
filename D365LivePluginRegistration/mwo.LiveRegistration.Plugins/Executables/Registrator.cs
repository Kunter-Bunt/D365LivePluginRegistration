using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Extensions;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using System;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class Registrator : ICRMExecutable<Entity>
    {
        public void Execute(IOrganizationService svc, ITracingService trace, IPluginExecutionContext ctx, Entity target, Entity preImage = null)
        {
            IPluginStepRegistrationManager registrationManager = new PluginStepRegistrationManager(svc);

            if (ctx.MessageName == "Create")
            {
                var res = registrationManager.Register("mwo.LiveRegistration.Plugins.EntryPoints.PostOpLiveRegistration", "Create", "contact", null, "Test", false, Models.Stage.PostOperation, null, "The Description");
                trace.Trace("Created new PluginStep: " +  res.ToString());
            }
            else if (ctx.MessageName == "Update")
            {
                var subject = preImage.Merge(target);
                registrationManager.Update(subject.GetAttributeValue<Guid>("pluginstepid"), "mwo.LiveRegistration.Plugins.EntryPoints.PostOpLiveRegistration", "Create", "contact", null, "Test", false, Models.Stage.PostOperation, null, "The Description");
                trace.Trace("updated PluginStep: " + subject.GetAttributeValue<Guid>("pluginstepid"));
            }

        }
    }
}
