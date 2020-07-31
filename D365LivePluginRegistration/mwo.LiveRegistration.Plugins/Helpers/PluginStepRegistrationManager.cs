using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Helpers
{
    public class PluginStepRegistrationManager : IPluginStepRegistrationManager
    {
        private readonly IOrganizationService Svc;

        public PluginStepRegistrationManager(IOrganizationService service)
        {
            Svc = service;
        }

        public void Delete(Guid id)
        {
            Svc.Delete(Sdkmessageprocessingstep.LogicalName, id);
        }

        public void Activate(Guid id)
        {
            Entity step = ComposeMoniker(id, Sdkmessageprocessingstep.StateActive, Sdkmessageprocessingstep.StatusActive);
            Svc.Update(step);
        }

        public void Deactivate(Guid id)
        {
            Entity step = ComposeMoniker(id, Sdkmessageprocessingstep.StateInactive, Sdkmessageprocessingstep.StatusInactive);
            Svc.Update(step);
        }

        public void Update(Guid id,
                            string pluginTypeName,
                            string sdkMessage,
                            string primaryEntity,
                            string secondaryEntity,
                            string stepconfiguration,
                            bool asynchronous,
                            Stage stage,
                            string filteringAttributes,
                            string description)
        {
            Entity step = ComposeEntity(pluginTypeName, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            step.Id = id;
            Svc.Update(step);
        }

        public Guid Register(string pluginTypeName,
                            string sdkMessage,
                            string primaryEntity,
                            string secondaryEntity,
                            string stepconfiguration,
                            bool asynchronous,
                            Stage stage,
                            string filteringAttributes,
                            string description)
        {
            Entity step = ComposeEntity(pluginTypeName, sdkMessage, primaryEntity, secondaryEntity, stepconfiguration, asynchronous, stage, filteringAttributes, description);
            return Svc.Create(step);
        }

        private Entity ComposeEntity(string pluginTypeName, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description)
        {
            Entity plugin = GetPlugin(pluginTypeName);
            Entity message = GetMessage(sdkMessage);
            Entity messageFilter = GetMessageFilter(message, primaryEntity, secondaryEntity);

            var entity = new Entity(Sdkmessageprocessingstep.LogicalName)
            {
                [Sdkmessageprocessingstep.Plugintypeid] = plugin.ToEntityReference(),
                [Sdkmessageprocessingstep.Sdkmessageid] = message.ToEntityReference(),
                [Sdkmessageprocessingstep.Sdkmessagefilterid] = messageFilter?.ToEntityReference(),
                [Sdkmessageprocessingstep.Name] = BuildName(pluginTypeName, sdkMessage, stage, primaryEntity, secondaryEntity, asynchronous),
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

        private Entity ComposeMoniker(Guid id, int statecode, int statuscode)
        {
            return new Entity(Sdkmessageprocessingstep.LogicalName)
            {
                Id = id,
                [Sdkmessageprocessingstep.Statecode] = statecode.ToOptionSetValue(),
                [Sdkmessageprocessingstep.Statuscode] = statuscode.ToOptionSetValue()
            };
        }

        private static string BuildName(string pluginTypeName, string sdkMessage, Stage stage, string primaryEntity, string secondaryEntity, bool asynchronous)
        {
            string name = string.Join("_", pluginTypeName, stage, sdkMessage);
            if (!string.IsNullOrEmpty(primaryEntity)) name = string.Join("_", name, primaryEntity);
            if (!string.IsNullOrEmpty(secondaryEntity)) name = string.Join("_", name, secondaryEntity);
            if (asynchronous) name = string.Join("_", name, "Asynchronous");
            return name;
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

        private Entity GetPlugin(string pluginTypeName)
        {
            var query = new QueryExpression(Plugintype.LogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(Plugintype.Typename, ConditionOperator.Equal, pluginTypeName);
            var results = Svc.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(pluginTypeName) + " does not exist");

            return results.Entities.First();
        }
    }
}
