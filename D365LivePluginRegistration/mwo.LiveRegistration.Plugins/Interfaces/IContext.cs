using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    interface IContext : IOrganizationService, ITracingService
    {
        IOrganizationServiceFactory Factory { get; }
        IPluginExecutionContext PluginExecutionContext { get; }
        Entity PreImage { get; }
        IOrganizationService Service { get; set; }
        Entity Subject { get; }
        Entity Target { get; }
        ITracingService Tracer { get; }
    }
}