using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Models;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    public interface IImageManager
    {
        void Delete(string imageName, EntityReference sdkMessageProcessingStepRef);
        void Upsert(ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes);
    }
}