using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Helpers
{
    /// <summary>
    /// Class will help interacting with Pre-/Post-Entity Images.
    /// </summary>
    public class ImageManager : IImageManager
    {
        private readonly IOrganizationService Service;

        public ImageManager(IOrganizationService svc)
        {
            Service = svc;
        }

        /// <summary>
        /// Deletes the image of the specified step
        /// </summary>
        public void Delete(EntityReference sdkMessageProcessingStepRef)
        {
            if (sdkMessageProcessingStepRef == null) return;

            var existing = Get(sdkMessageProcessingStepRef);
            if (existing != null) Service.Delete(SdkMessageProcessingStepImage.EntityLogicalName, existing.Id);
        }

        /// <summary>
        /// Will create or update the image of the step with the specified values.
        /// </summary>
        public void Upsert(ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            if (string.IsNullOrEmpty(imageName)) return;
            if (sdkMessageProcessingStepRef == null) return;

            var existing = Get(sdkMessageProcessingStepRef);
            if (existing != null) Update(existing.Id, imageType, imageName, sdkMessageProcessingStepRef, attributes);
            else Create(imageType, imageName, sdkMessageProcessingStepRef, attributes);
        }

        private void Update(Guid id, ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            Entity image = ComposeEntity(imageType, imageName, sdkMessageProcessingStepRef, attributes);
            image.Id = id;

            Service.Update(image);
        }

        private void Create(ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            Entity image = ComposeEntity(imageType, imageName, sdkMessageProcessingStepRef, attributes);

            Service.Create(image);
        }

        private static Entity ComposeEntity(ImageType imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            var image = new SdkMessageProcessingStepImage
            {
                ImageType = MapImageType(imageType),
                Name = imageName,
                EntityAlias = imageName,
                SdkMessageProcessingStepId = sdkMessageProcessingStepRef,
                MessagePropertyName = "Target",
                Attributes1 = attributes
            };
            return image;
        }

        private static sdkmessageprocessingstepimage_imagetype MapImageType(ImageType imageType)
        {
            switch(imageType)
            {
                case ImageType.PreImage: return sdkmessageprocessingstepimage_imagetype.PreImage;
                case ImageType.PostImage: return sdkmessageprocessingstepimage_imagetype.PostImage;
                case ImageType.Both: return sdkmessageprocessingstepimage_imagetype.Both;
                default: throw new ArgumentOutOfRangeException(nameof(imageType));
            }
        }

        private Entity Get(EntityReference sdkMessageProcessingStepRef)
        {
            var query = new QueryExpression(SdkMessageProcessingStepImage.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(new ConditionExpression("sdkmessageprocessingstepid", ConditionOperator.Equal, sdkMessageProcessingStepRef.Id));
            var results = Service.RetrieveMultiple(query);

            return results.Entities.FirstOrDefault();
        }
    }
}
