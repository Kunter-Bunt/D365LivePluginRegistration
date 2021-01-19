using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Helpers
{
    /// <summary>
    /// Class will help interacting with Plugin Steps.
    /// </summary>
    public class PluginStepRegistrationManager : IPluginStepRegistrationManager
    {
        private readonly IOrganizationService Svc;

        public PluginStepRegistrationManager(IOrganizationService service)
        {
            Svc = service;
        }

        /// <summary>
        /// Removes the step.
        /// </summary>
        public void Delete(Guid id)
        {
            Svc.Delete(SdkMessageProcessingStep.EntityLogicalName, id);
        }

        /// <summary>
        /// Enables the given step.
        /// </summary>
        public void Activate(Guid id)
        {
            Entity step = ComposeMoniker(id, SdkMessageProcessingStepState.Enabled, SdkMessageProcessingStep_StatusCode.Enabled);
            Svc.Update(step);
        }

        /// <summary>
        /// Disables the given step.
        /// </summary>
        public void Deactivate(Guid id)
        {
            Entity step = ComposeMoniker(id, SdkMessageProcessingStepState.Disabled, SdkMessageProcessingStep_StatusCode.Disabled);
            Svc.Update(step);
        }

        /// <summary>
        /// Given the existing Step, updates its properties.
        /// </summary>
        public void Update(Guid id,
                            string eventHandler,
                            EventHandlerType? eventHandlerType,
                            string name,
                            string sdkMessage,
                            string primaryEntity,
                            string secondaryEntity,
                            string stepconfiguration,
                            bool asynchronous,
                            Stage stage,
                            string filteringAttributes,
                            string description)
        {
            Entity step = ComposeEntity(eventHandler, eventHandlerType, name, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            step.Id = id;
            Svc.Update(step);
        }

        /// <summary>
        /// Creates a new Step for the specified plugintype.
        /// </summary>
        public Guid Register(
                            string eventHandler,
                            EventHandlerType? eventHandlerType,
                            string name,
                            string sdkMessage,
                            string primaryEntity,
                            string secondaryEntity,
                            string stepconfiguration,
                            bool asynchronous,
                            Stage stage,
                            string filteringAttributes,
                            string description)
        {
            Entity step = ComposeEntity(eventHandler, eventHandlerType, name, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            return Svc.Create(step);
        }

        private Entity ComposeEntity(string eventHandler, EventHandlerType? eventHandlerType, string name, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description)
        {
            EntityReference handler = GetEventHandler(eventHandler, eventHandlerType);
            EntityReference message = GetMessage(sdkMessage);
            EntityReference messageFilter = GetMessageFilter(message, primaryEntity, secondaryEntity);

            var entity = new SdkMessageProcessingStep
            {
                EventHandler = handler,
                SdkMessageId = message,
                SdkMessageFilterId = messageFilter,
                Name = name,
                Configuration = stepconfiguration,
                Mode = asynchronous ? SdkMessageProcessingStep_Mode.Asynchronous : SdkMessageProcessingStep_Mode.Synchronous,
                Rank = 1,
                Stage = MapMode(stage),
                SupportedDeployment = SdkMessageProcessingStep_SupportedDeployment.ServerOnly,
                FilteringAttributes = filteringAttributes,
                Description = description
            };
            if (asynchronous) entity.AsyncAutoDelete = true;
            return entity;
        }

        private SdkMessageProcessingStep_Stage MapMode(Stage stage)
        {
            switch (stage)
            {
                case Stage.PreValidation: return SdkMessageProcessingStep_Stage.Prevalidation;
                case Stage.PreOperation: return SdkMessageProcessingStep_Stage.Preoperation;
                case Stage.PostOperation: return SdkMessageProcessingStep_Stage.Postoperation;
                default: throw new ArgumentOutOfRangeException(nameof(stage));
            }
        }

        private EntityReference GetEventHandler(string name, EventHandlerType? type)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (type == null) throw new ArgumentNullException(nameof(type));

            switch (type)
            {
                case EventHandlerType.PluginType:
                    return GetPluginTypeId(name);
                case EventHandlerType.ServiceEndpoint:
                    return GetServiceEndpointId(name);
                default:
                    throw new InvalidOperationException($"Unrecognized type: {type}");
            }
        }

        private EntityReference GetServiceEndpointId(string name)
        {
            var query = new QueryExpression(ServiceEndpoint.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(ServiceEndpoint.Fields.Name, ConditionOperator.Equal, name);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(name) + " does not exist");

            var plugintype = results.Entities.First();
            return plugintype.ToEntityReference();
        }

        private EntityReference GetPluginTypeId(string pluginTypeName)
        {
            var query = new QueryExpression(PluginType.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(PluginType.Fields.TypeName, ConditionOperator.Equal, pluginTypeName);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(pluginTypeName) + " does not exist");

            var plugintype = results.Entities.First();
            return plugintype.ToEntityReference();
        }

        private Entity ComposeMoniker(Guid id, SdkMessageProcessingStepState statecode, SdkMessageProcessingStep_StatusCode statuscode)
        {
            return new SdkMessageProcessingStep
            {
                Id = id,
                StateCode = statecode,
                StatusCode = statuscode
            };
        }

        private EntityReference GetMessageFilter(EntityReference message, string primaryEntity, string secondaryEntity)
        {
            if (string.IsNullOrEmpty(primaryEntity) && string.IsNullOrEmpty(secondaryEntity)) return null;

            var query = new QueryExpression(SdkMessageFilter.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(SdkMessageFilter.Fields.SdkMessageId, ConditionOperator.Equal, message.Id);
            if (!string.IsNullOrEmpty(primaryEntity)) query.Criteria.AddCondition(SdkMessageFilter.Fields.PrimaryObjectTypeCode, ConditionOperator.Equal, primaryEntity);
            if (!string.IsNullOrEmpty(secondaryEntity)) query.Criteria.AddCondition(SdkMessageFilter.Fields.SecondaryObjectTypeCode, ConditionOperator.Equal, secondaryEntity);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException($"Message does not exist on {primaryEntity} {secondaryEntity}");

            return results.Entities.First().ToEntityReference();
        }

        private EntityReference GetMessage(string sdkMessageName)
        {
            var query = new QueryExpression(SdkMessage.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(SdkMessage.Fields.Name, ConditionOperator.Equal, sdkMessageName);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(sdkMessageName) + " does not exist");

            return results.Entities.First().ToEntityReference();
        }
    }
}
