using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    /// <summary>
    /// Class will help interacting with Plugin Steps.
    /// </summary>
    public interface IPluginStepRegistrationManager
    {
        /// <summary>
        /// Creates a new Step for the specified plugintype.
        /// </summary>
        Guid Register(string eventHandler, EventHandlerType? eventHandlerType, string name, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description, int? rank, bool? asyncAutoDelete);
        /// <summary>
        /// Given the existing Step, updates its properties.
        /// </summary>
        void Update(Guid id, string eventHandler, EventHandlerType? eventHandlerType, string name, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description, int? rank, bool? asyncAutoDelete);
        /// <summary>
        /// Removes the step.
        /// </summary>
        void Delete(Guid id);
        /// <summary>
        /// Enables the given step.
        /// </summary>
        void Activate(Guid id);
        /// <summary>
        /// Disables the given step.
        /// </summary>
        void Deactivate(Guid id);
    }
}