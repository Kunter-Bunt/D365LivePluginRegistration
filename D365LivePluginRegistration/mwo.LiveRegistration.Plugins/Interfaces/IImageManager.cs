using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Models;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    /// <summary>
    /// Class will help interacting with Pre-/Post-Entity Images.
    /// </summary>
    public interface IImageManager
    {
        /// <summary>
        /// Deletes the image of the specified step
        /// </summary>
        void Delete(EntityReference sdkMessageProcessingStepRef);
                /// <summary>
        /// Will create or update the image of the step with the specified values.
        /// </summary>
        void Upsert(ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes);
    }
}