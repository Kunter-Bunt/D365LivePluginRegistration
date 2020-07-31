using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    public interface ICRMContext : IOrganizationService, ITracingService, ICRMEvent
    {
    }
}