using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    public interface ICRMEvent
    {
        string MessageName { get; }
        Entity PreImage { get; }
        Entity Subject { get; }
        Entity Target { get; }
    }
}