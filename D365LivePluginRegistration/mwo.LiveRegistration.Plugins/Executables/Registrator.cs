using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class Registrator : ICRMExecutable<Entity>
    {
        public void Execute(IOrganizationService svc, ITracingService trace, Entity target, Entity preImage = null)
        {
            IPluginStepRegistrationManager registrationManager = new PluginStepRegistrationManager(svc);
            var res = registrationManager.Register("mwo.LiveRegistration.Plugins.EntryPoints.PostOpLiveRegistration", "Create", "contact", null, "Test", false, Models.Stage.PostOperation, null, "The Description");
            trace.Trace(res.ToString());
        }
    }
}
