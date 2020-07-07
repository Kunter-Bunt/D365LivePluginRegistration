using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Executables;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.EntryPoints
{
    [CrmPluginRegistration(MessageNameEnum.Create, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Create", 1, IsolationModeEnum.Sandbox)]
    [CrmPluginRegistration(MessageNameEnum.Update, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Update", 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName)]
    [CrmPluginRegistration(MessageNameEnum.Delete, "mwo_pluginstepregistration",
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, "",
    "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Delete", 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName)]
    public class PreOpLiveRegistration : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            IContext context = new CRMPluginContext(serviceProvider);

            try
            {
                new Registrator(context).Execute(context);
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message, e);
            }
        }
    }
}
