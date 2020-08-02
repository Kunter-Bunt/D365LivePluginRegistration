using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Extensions;
using mwo.LiveRegistration.Plugins.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace mwo.LiveRegistration.Plugins.Models
{
    /// <summary>
    /// Generates a Context from an IServiceProvider to serve executables.
    /// </summary>
    public class CRMPluginContext : ICRMContext
    {
        public const string TargetName = "Target";
        public const string PreImageName = "Default";

        public Entity Target { get; private set; }
        public Entity PreImage { get; private set; }
        public Entity Subject { get; private set; }
        public IOrganizationService Service { get; private set; }
        public IPluginExecutionContext PluginExecutionContext { get; private set; }
        public IOrganizationServiceFactory Factory { get; private set; }
        public ITracingService Tracer { get; private set; }

        public string MessageName => PluginExecutionContext.MessageName;

        public CRMPluginContext(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null) throw new InvalidPluginExecutionException(nameof(serviceProvider));
            PluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            Factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            Tracer = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            if (PluginExecutionContext.InputParameters.ContainsKey(TargetName)
                && (PluginExecutionContext.InputParameters[TargetName] is Entity targetEntity))
                Target = targetEntity;
            else if (PluginExecutionContext.InputParameters.ContainsKey(TargetName)
                && (PluginExecutionContext.InputParameters[TargetName] is EntityReference targetRef))
                Target = new Entity(targetRef.LogicalName, targetRef.Id);
            else
            {
                Tracer.Trace("Context did not have an Entity as Target, aborting.");
                throw new InvalidPluginExecutionException(TargetName);
            }

            if (PluginExecutionContext.PreEntityImages.ContainsKey(PreImageName)
                && (PluginExecutionContext.PreEntityImages[PreImageName] is Entity preImageEntity))
                PreImage = preImageEntity;

            Subject = PreImage == null ? Target : PreImage.Merge(Target);

            Service = Factory.CreateOrganizationService(PluginExecutionContext.UserId);
        }

        #region IOrganizationService
        [ExcludeFromCodeCoverage]
        public Guid Create(Entity entity) => Service.Create(entity);

        [ExcludeFromCodeCoverage]
        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => Service.Retrieve(entityName, id, columnSet);

        [ExcludeFromCodeCoverage]
        public void Update(Entity entity) => Service.Update(entity);

        [ExcludeFromCodeCoverage]
        public void Delete(string entityName, Guid id) => Service.Delete(entityName, id);

        [ExcludeFromCodeCoverage]
        public OrganizationResponse Execute(OrganizationRequest request) => Service.Execute(request);

        [ExcludeFromCodeCoverage]
        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) => Service.Associate(entityName, entityId, relationship, relatedEntities);

        [ExcludeFromCodeCoverage]
        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) => Service.Disassociate(entityName, entityId, relationship, relatedEntities);

        [ExcludeFromCodeCoverage]
        public EntityCollection RetrieveMultiple(QueryBase query) => Service.RetrieveMultiple(query);
        #endregion

        #region ITracingService
        [ExcludeFromCodeCoverage]
        public void Trace(string format, params object[] args) => Tracer.Trace(format, args);
        #endregion
    }
}
