namespace mwo.LiveRegistration.Plugins.Interfaces
{
    /// <summary>
    /// Common Entrypoint for logic. Plugins react to an event in the CRM and execute from there.
    /// </summary>
    public interface ICRMExecutable
    {
        /// <summary>
        /// Will execute a logic based on the Event, no feedback as feedback will be the side effects in the CRM.
        /// </summary>
        void Execute(ICRMEvent context);
    }
}
