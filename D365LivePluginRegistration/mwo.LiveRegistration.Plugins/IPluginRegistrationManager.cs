using System;

namespace mwo.LiveRegistration.Plugins
{
    public interface IPluginStepRegistrationManager
    {
        Guid Register(string pluginTypeName, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description);
        void Update(Guid id, string pluginTypeName, string sdkMessage, string primaryEntity, string secondaryEntity, string stepconfiguration, bool asynchronous, Stage stage, string filteringAttributes, string description);
        void Delete(Guid id);
        void Activate(Guid id);
        void Deactivate(Guid id);
    }
}