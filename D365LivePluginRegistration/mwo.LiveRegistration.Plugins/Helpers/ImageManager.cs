﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Helpers
{
    public class ImageManager : IImageManager
    {
        private readonly IOrganizationService Service;

        public ImageManager(IOrganizationService svc)
        {
            Service = svc;
        }

        public void Delete(EntityReference sdkMessageProcessingStepRef)
        {
            if (sdkMessageProcessingStepRef == null) return;

            var existing = Get(sdkMessageProcessingStepRef);
            if (existing != null) Service.Delete("sdkmessageprocessingstepimage", existing.Id);
        }

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

        private Entity Get(EntityReference sdkMessageProcessingStepRef)
        {
            var query = new QueryExpression("sdkmessageprocessingstepimage")
            {
                ColumnSet = new ColumnSet(false)
            };
            query.Criteria.AddCondition(new ConditionExpression("sdkmessageprocessingstepid", ConditionOperator.Equal, sdkMessageProcessingStepRef.Id));
            var results = Service.RetrieveMultiple(query);

            return results.Entities.FirstOrDefault();
        }
    }
}
