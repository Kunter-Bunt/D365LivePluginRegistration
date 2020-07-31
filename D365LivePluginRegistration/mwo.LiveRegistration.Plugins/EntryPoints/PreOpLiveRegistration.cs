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
    [CrmPluginRegistration(MessageNameEnum.Delete, PluginRegistration.LogicalName,
        StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
        PluginNameDelete, Sdkmessageprocessingstep.RankDefault, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName)]
    public class PreOpLiveRegistration : IPlugin
    {
        public const string FilterAttribute = "";
        public const string PluginNameCreate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Create";
        public const string PluginNameUpdate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Update";
        public const string PluginNameDelete = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Delete";

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
