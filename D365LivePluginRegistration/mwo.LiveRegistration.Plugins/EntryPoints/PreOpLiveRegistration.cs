using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Executables;
using System;
using System.ServiceModel;

namespace mwo.LiveRegistration.Plugins.EntryPoints
{
    [CrmPluginRegistration(MessageNameEnum.Create, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Create", 1, IsolationModeEnum.Sandbox)]
    [CrmPluginRegistration(MessageNameEnum.Update, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Update", 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = "Default")]
    [CrmPluginRegistration(MessageNameEnum.Delete, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Delete", 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = "Default")]
    public class PreOpLiveRegistration : IPlugin
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
            else if (pluginExecutionContext.InputParameters.ContainsKey(TargetName)
                && (pluginExecutionContext.InputParameters[TargetName] is EntityReference targetRef))
                target = new Entity(targetRef.LogicalName, targetRef.Id);
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

            try
            {
                new Registrator().Execute(svc, tracingService, pluginExecutionContext, target, preImage);
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message, e);
            }
        }
    }
}
