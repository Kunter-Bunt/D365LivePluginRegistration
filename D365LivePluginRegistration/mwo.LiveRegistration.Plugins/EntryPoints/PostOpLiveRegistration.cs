using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Executables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwo.LiveRegistration.Plugins.EntryPoints
{
    [CrmPluginRegistration(MessageNameEnum.Create, "account",
    StageEnum.PostOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PostOpLiveRegistration", 1, IsolationModeEnum.Sandbox)]
    public class PostOpLiveRegistration : IPlugin
    {
        public const string TargetName = "Target";
        public const string PreImageName = "Default";

        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new InvalidPluginExecutionException(nameof(serviceProvider));
            IPluginExecutionContext pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            Entity target;
            if (pluginExecutionContext.InputParameters.ContainsKey(TargetName)
                && (pluginExecutionContext.InputParameters[TargetName] is Entity targetEntity))
                target = targetEntity;
            else
            {
                tracingService.Trace("Context did not have an Entity as Target, aborting.");
                return;
            }

            Entity preImage = null;
            if (pluginExecutionContext.PreEntityImages.ContainsKey(PreImageName)
                && (pluginExecutionContext.PreEntityImages[PreImageName] is Entity preImageEntity))
                preImage = preImageEntity;

            IOrganizationService svc = factory.CreateOrganizationService(pluginExecutionContext.UserId);

            new Registrator().Execute(svc, tracingService, target, preImage);
        }
    }
}
