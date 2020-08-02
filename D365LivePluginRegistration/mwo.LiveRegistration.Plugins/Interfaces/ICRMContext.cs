using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    /// <summary>
    /// Combination Interface that can be generated from a IServiceProvider.
    /// </summary>
    public interface ICRMContext : IOrganizationService, ITracingService, ICRMEvent
    {
    }
}