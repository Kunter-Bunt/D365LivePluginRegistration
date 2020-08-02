using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    /// <summary>
    /// Defines comon properties of an Event happening in CRM.
    /// </summary>
    public interface ICRMEvent
    {
        /// <summary>
        /// The message, like Create, Update, Delete.
        /// </summary>
        string MessageName { get; }
        /// <summary>
        /// If a preimage was registered will hold that entity
        /// </summary>
        Entity PreImage { get; }
        /// <summary>
        /// If a preimage was registered will hold a combination of preimage and target, otherwise it is identical to the target.
        /// </summary>
        Entity Subject { get; }
        /// <summary>
        /// The target of the event.
        /// </summary>
        Entity Target { get; }
    }
}