using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    interface ICRMExecutable<T>
    {
        void Execute(IOrganizationService svc, ITracingService trace, IPluginExecutionContext ctx, T target, T preImage = default);
    }
}
