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
            Svc.Delete(Sdkmessageprocessingstep.LogicalName, id);
        }

        /// <summary>
        /// Enables the given step.
        /// </summary>
        public void Activate(Guid id)
        {
            Entity step = ComposeMoniker(id, Sdkmessageprocessingstep.StateActive, Sdkmessageprocessingstep.StatusActive);
            Svc.Update(step);
        }

        /// <summary>
        /// Disables the given step.
        /// </summary>
        public void Deactivate(Guid id)
        {
            Entity step = ComposeMoniker(id, Sdkmessageprocessingstep.StateInactive, Sdkmessageprocessingstep.StatusInactive);
            Svc.Update(step);
        }

        /// <summary>
        /// Given the existing Step, updates its properties.
        /// </summary>
        public void Update(Guid id,
                            EntityReference eventHandler,
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
            Entity step = ComposeEntity(eventHandler, name, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            step.Id = id;
            Svc.Update(step);
        }

        /// <summary>
        /// Creates a new Step for the specified plugintype.
        /// </summary>
        public Guid Register(EntityReference eventHandler,
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
            Entity step = ComposeEntity(eventHandler, name, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            return Svc.Create(step);
        }

        private Entity ComposeEntity(EntityReference eventHandler, string name, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description)
        {
            EntityReference handler = GetEventHandler(eventHandler);
            Entity message = GetMessage(sdkMessage);
            Entity messageFilter = GetMessageFilter(message, primaryEntity, secondaryEntity);

            var entity = new Entity(Sdkmessageprocessingstep.LogicalName)
            {
                [Sdkmessageprocessingstep.EventHandler] = handler,
                [Sdkmessageprocessingstep.Sdkmessageid] = message.ToEntityReference(),
                [Sdkmessageprocessingstep.Sdkmessagefilterid] = messageFilter?.ToEntityReference(),
                [Sdkmessageprocessingstep.Name] = name,
                [Sdkmessageprocessingstep.Configuration] = stepconfiguration,
                [Sdkmessageprocessingstep.Mode] = asynchronous ?
                                                    Sdkmessageprocessingstep.ModeAsynchronous.ToOptionSetValue() :
                                                    Sdkmessageprocessingstep.ModeSynchronous.ToOptionSetValue(),
                [Sdkmessageprocessingstep.Rank] = Sdkmessageprocessingstep.RankDefault,
                [Sdkmessageprocessingstep.Stage] = ((int)stage).ToOptionSetValue(),
                [Sdkmessageprocessingstep.Supporteddeployment] = Sdkmessageprocessingstep.SupporteddeploymentServerOnly.ToOptionSetValue(),
                [Sdkmessageprocessingstep.Invocationsource] = Sdkmessageprocessingstep.InvocationsourceParent.ToOptionSetValue(),
                [Sdkmessageprocessingstep.Filteringattributes] = filteringAttributes,
                [Sdkmessageprocessingstep.Description] = description,
            };
            if (asynchronous) entity[Sdkmessageprocessingstep.Asyncautodelete] = true;
            return entity;
        }

        private EntityReference GetEventHandler(EntityReference eventHandler)
        {
            if (eventHandler == null) throw new ArgumentNullException(nameof(eventHandler));

            var handler = Svc.Retrieve(eventHandler.LogicalName, eventHandler.Id, new ColumnSet(PluginEventHandler.CrmEventHandlerId, PluginEventHandler.TypeLogicalName));
            var logicalName = handler.GetAttributeValue<string>(PluginEventHandler.TypeLogicalName);
            var hasId = Guid.TryParse(handler.GetAttributeValue<string>(PluginEventHandler.CrmEventHandlerId), out Guid id);
            if (!hasId) throw new InvalidOperationException("EventHandler has no valid Id, please try to recreate it.");
            if (string.IsNullOrEmpty(logicalName)) throw new InvalidOperationException("EventHandler has no valid logical name, please try to recreate it.");

            return new EntityReference(logicalName, id);
        }

        private Entity ComposeMoniker(Guid id, int statecode, int statuscode)
        {
            return new Entity(Sdkmessageprocessingstep.LogicalName)
            {
                Id = id,
                [Sdkmessageprocessingstep.Statecode] = statecode.ToOptionSetValue(),
                [Sdkmessageprocessingstep.Statuscode] = statuscode.ToOptionSetValue()
            };
        }

        private Entity GetMessageFilter(Entity message, string primaryEntity, string secondaryEntity)
        {
            if (string.IsNullOrEmpty(primaryEntity) && string.IsNullOrEmpty(secondaryEntity)) return null;

            var query = new QueryExpression(Sdkmessagefilter.LogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(Sdkmessagefilter.Sdkmessageid, ConditionOperator.Equal, message.Id);
            if (!string.IsNullOrEmpty(primaryEntity)) query.Criteria.AddCondition(Sdkmessagefilter.Primaryobjecttypecode, ConditionOperator.Equal, primaryEntity);
            if (!string.IsNullOrEmpty(secondaryEntity)) query.Criteria.AddCondition(Sdkmessagefilter.Secondaryobjecttypecode, ConditionOperator.Equal, secondaryEntity);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException($"Message does not exist on {primaryEntity} {secondaryEntity}");

            return results.Entities.First();
        }

        private Entity GetMessage(string sdkMessageName)
        {
            var query = new QueryExpression(Sdkmessage.LogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(Sdkmessage.Name, ConditionOperator.Equal, sdkMessageName);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(sdkMessageName) + " does not exist");

            return results.Entities.First();
        }
    }
}
