using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Executables;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.EntryPoints
{
    /// <summary>
    /// Entrypoint Class implementing IPlugin, to be registered in CRM.
    /// </summary>
    [CrmPluginRegistration(MessageNameEnum.Create, mwo_PluginStepRegistration.EntityLogicalName,
        StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
        PluginNameCreate, 1, IsolationModeEnum.Sandbox)]
    [CrmPluginRegistration(MessageNameEnum.Update, mwo_PluginStepRegistration.EntityLogicalName,
        StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
        PluginNameUpdate, 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName, Image1Attributes = "")]
    [CrmPluginRegistration(MessageNameEnum.Delete, mwo_PluginStepRegistration.EntityLogicalName,
        StageEnum.PreOperation, ExecutionModeEnum.Synchronous, FilterAttribute,
        PluginNameDelete, 1, IsolationModeEnum.Sandbox,
        Image1Type = ImageTypeEnum.PreImage, Image1Name = CRMPluginContext.PreImageName, Image1Attributes = "")]
    public class PreOpLiveRegistration : IPlugin
    {
        public const string FilterAttribute = "";
        public const string PluginNameCreate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Create";
        public const string PluginNameUpdate = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Update";
        public const string PluginNameDelete = "mwo.LiveRegistration.Plugins.EntryPoints.PreOpLiveRegistration_Delete";

        public void Execute(IServiceProvider serviceProvider)
        {
            ICRMContext context = new CRMPluginContext(serviceProvider);

            try
            {
                new Registrator(context, context).Execute(context);
            }
            catch (Exception e)
            {
                throw new InvalidPluginExecutionException(e.Message, e);
            }
        }
    }
}
