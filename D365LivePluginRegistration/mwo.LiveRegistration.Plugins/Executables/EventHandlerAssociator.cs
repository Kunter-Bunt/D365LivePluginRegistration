using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class EventHandlerAssociator : ICRMExecutable
    {
        private ITracingService Tracer { get; set; }
        private IOrganizationService Service { get; set; }

        public EventHandlerAssociator(IOrganizationService service, ITracingService tracer)
        {
            Tracer = tracer;
            Service = service;
        }

        public void Execute(ICRMEvent context)
        {
            var subject = context.Subject;
            var typeOption = subject.GetAttributeValue<OptionSetValue>(PluginEventHandler.Type);
            if (typeOption == null) throw new InvalidOperationException("A type is required!");
            var name = subject.GetAttributeValue<string>(PluginEventHandler.Name);
            if (string.IsNullOrEmpty(name)) throw new InvalidOperationException("A name is required!");

            var type = typeOption.Value.ToEventHandlerType();
            switch (type)
            {
                case EventHandlerType.PluginType:
                    context.Target[PluginEventHandler.CrmEventHandlerId] = GetPluginTypeId(name);
                    context.Target[PluginEventHandler.TypeLogicalName] = Plugintype.LogicalName;
                    break;
                case EventHandlerType.ServiceEndpoint:
                    context.Target[PluginEventHandler.CrmEventHandlerId] = GetServiceEndpointId(name);
                    context.Target[PluginEventHandler.TypeLogicalName] = ServiceEndpoint.LogicalName;
                    break;
                default:
                    throw new InvalidOperationException($"Unrecognized type: {typeOption.Value}");
            }
        }

        private object GetServiceEndpointId(string name)
        {
            var query = new QueryExpression(ServiceEndpoint.LogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(ServiceEndpoint.Name, ConditionOperator.Equal, name);
            var results = Service.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(name) + " does not exist");

            var plugintype = results.Entities.First();
            var id = plugintype.Id.ToString();
            Tracer.Trace($"Service Endpoint Id: {id}");

            return id;
        }

        private string GetPluginTypeId(string pluginTypeName)
        {
            var query = new QueryExpression(Plugintype.LogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(Plugintype.Typename, ConditionOperator.Equal, pluginTypeName);
            var results = Service.RetrieveMultiple(query);
            if (!results.Entities.Any()) throw new ArgumentException(nameof(pluginTypeName) + " does not exist");

            var plugintype = results.Entities.First();
            var id = plugintype.Id.ToString();
            Tracer.Trace($"Plugin Type Id: {id}");

            return id;
        }
    }
}
