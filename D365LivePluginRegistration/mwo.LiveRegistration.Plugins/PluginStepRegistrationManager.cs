using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins
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
            Svc.Delete("sdkmessageprocessingstep", id);
        }

        public void Activate(Guid id)
        {
            Entity step = ComposeMoniker(id, 0, 1);
            Svc.Update(step);
        }

        public void Deactivate(Guid id)
        {
            Entity step = ComposeMoniker(id, 1, 2);
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

            var entity = new Entity("sdkmessageprocessingstep")
            {
                ["plugintypeid"] = plugin.ToEntityReference(),
                ["sdkmessageid"] = message.ToEntityReference(),
                ["sdkmessagefilterid"] = messageFilter?.ToEntityReference(),
                ["asyncautodelete"] = 1.ToOptionSetValue(),
                ["name"] = BuildName(pluginTypeName, sdkMessage, stage, primaryEntity, secondaryEntity, asynchronous),
                ["configuration"] = stepconfiguration,
                ["mode"] = asynchronous ? 1.ToOptionSetValue() : 0.ToOptionSetValue(),
                ["rank"] = 1,
                ["stage"] = ((int)stage).ToOptionSetValue(),
                ["supporteddeployment"] = 0.ToOptionSetValue(),
                ["invocationsource"] = 0.ToOptionSetValue(),
                ["filteringattributes"] = filteringAttributes,
                ["description"] = description,
            };
            return entity;
        }

        private Entity ComposeMoniker(Guid id, int statecode, int statuscode)
        {
            return new Entity("sdkmessageprocessingstep")
            {
                Id = id,
                ["statecode"] = statecode.ToOptionSetValue(),
                ["statuscode"] = statuscode.ToOptionSetValue()
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
            var query = new QueryExpression("sdkmessagefilter")
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition("sdkmessageid", ConditionOperator.Equal, message.Id);
            if (!string.IsNullOrEmpty(primaryEntity)) query.Criteria.AddCondition("primaryobjecttypecode", ConditionOperator.Equal, primaryEntity);
            if (!string.IsNullOrEmpty(secondaryEntity)) query.Criteria.AddCondition("secondaryobjecttypecode", ConditionOperator.Equal, secondaryEntity);
            var results = Svc.RetrieveMultiple(query);
            var filter = results.Entities.FirstOrDefault();
            return filter;
        }

        private Entity GetMessage(string sdkMessageName)
        {
            var query = new QueryExpression("sdkmessage")
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition("name", ConditionOperator.Equal, sdkMessageName);
            var results = Svc.RetrieveMultiple(query);
            if (results.Entities.Count <= 0) throw new ArgumentException(nameof(sdkMessageName));
            var message = results.Entities.First();
            return message;
        }

        private Entity GetPlugin(string pluginTypeName)
        {
            var query = new QueryExpression("plugintype")
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition("typename", ConditionOperator.Equal, pluginTypeName);
            var results = Svc.RetrieveMultiple(query);
            if (results.Entities.Count <= 0) throw new ArgumentException(nameof(pluginTypeName));
            var plugin = results.Entities.First();
            return plugin;
        }
    }
}
