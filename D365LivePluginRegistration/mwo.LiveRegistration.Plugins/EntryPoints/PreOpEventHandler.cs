using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Executables;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.EntryPoints
{
    [CrmPluginRegistration(MessageNameEnum.Create, PluginRegistration.LogicalName,
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
    PluginNameCreate, Sdkmessageprocessingstep.RankDefault, IsolationModeEnum.Sandbox)]
    [CrmPluginRegistration(MessageNameEnum.Update, PluginRegistration.LogicalName,
    StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
    PluginNameUpdate, Sdkmessageprocessingstep.RankDefault, IsolationModeEnum.Sandbox,
    Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName)]
    public class PreOpEventHandler : IPlugin
    {
        public const string FilterAttribute = "";
        public const string PluginNameCreate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpEventHandler_Create";
        public const string PluginNameUpdate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpEventHandler_Update";


        public void Execute(IServiceProvider serviceProvider)
        {
            ICRMContext context = new CRMPluginContext(serviceProvider);

            try
            {
                new EventHandlerAssociator(context, context).Execute(context);
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message, e);
            }
        }

    }
}
