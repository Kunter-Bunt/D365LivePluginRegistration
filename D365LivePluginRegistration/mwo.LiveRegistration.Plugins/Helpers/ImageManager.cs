using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Helpers
{
    public class ImageManager
    {
        private readonly IOrganizationService Service;

        public ImageManager(IOrganizationService svc)
        {
            Service = svc;
        }

        public void Upsert(ImageTypeEnum imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            var existing = Get(imageName, sdkMessageProcessingStepRef);
            if (existing != null) Update(existing.Id, imageType, imageName, sdkMessageProcessingStepRef, attributes);
            else Create(imageType, imageName, sdkMessageProcessingStepRef, attributes);
        }

        private void Update(Guid id, ImageTypeEnum imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            Entity image = ComposeEntity(imageType, imageName, sdkMessageProcessingStepRef, attributes);
            image.Id = id;

            Service.Update(image);
        }

        private void Create(ImageTypeEnum imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            Entity image = ComposeEntity(imageType, imageName, sdkMessageProcessingStepRef, attributes);

            Service.Create(image);
        }

        private static Entity ComposeEntity(ImageTypeEnum imageType, string imageName, EntityReference sdkMessageProcessingStepRef, string attributes)
        {
            var image = new Entity("sdkmessageprocessingstepimage")
            {
                ["imagetype"] = new OptionSetValue((int)imageType),//Types are matched!
                ["name"] = imageName,
                ["entityalias"] = imageName,
                ["sdkmessageprocessingstepid"] = sdkMessageProcessingStepRef,
                ["messagepropertyname"] = "Target",
                ["attributes"] = attributes,
            };
            return image;
        }

        private Entity Get(string imageName, EntityReference sdkMessageProcessingStepRef)
        {
            var query = new QueryExpression("sdkmessageprocessingstepimage")
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition("name", ConditionOperator.Equal, imageName);
            query.Criteria.AddCondition("sdkmessageprocessingstepid", ConditionOperator.Equal, sdkMessageProcessingStepRef);
            var results = Service.RetrieveMultiple(query);

            return results.Entities.FirstOrDefault();
        }
    }
}
