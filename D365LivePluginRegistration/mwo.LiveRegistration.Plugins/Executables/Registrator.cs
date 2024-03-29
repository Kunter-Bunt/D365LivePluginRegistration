﻿using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.Executables
{
    /// <summary>
    /// Main Logic class managing registration step and image.
    /// </summary>
    class Registrator : ICRMExecutable
    {
        private IPluginStepRegistrationManager StepManager { get; set; }
        private IImageManager ImageManager { get; set; }
        private ITracingService Tracer { get; set; }

        public Registrator(IOrganizationService service, ITracingService tracer)
        {
            StepManager = new PluginStepRegistrationManager(service);
            ImageManager = new ImageManager(service);
            Tracer = tracer;
        }

        public void Execute(ICRMEvent context)
        {
            var subject = context.Subject.ToEntity<mwo_PluginStepRegistration>();
            if (!subject.mwo_Managed == true) return;

            var msg = context.MessageName.ToUpperInvariant();
            Guid pluginStepId;
            var hasId = Guid.TryParse(subject.mwo_PluginStepId, out pluginStepId);
            if (msg == CRMMessages.Delete && hasId)
            {
                DoDelete(context, pluginStepId, subject);
            }
            else if (msg == CRMMessages.Update && hasId)
            {
                DoUpdate(context, pluginStepId, subject);
                if (context.Target.Contains("statecode"))
                    DoManageStage(context, pluginStepId, subject);
            }
            else if ((msg == CRMMessages.Update || msg == CRMMessages.Create) && !hasId)
            {
                DoCreate(context, subject);
            }
            else
            {
                Tracer.Trace($"Nothing to do for {msg} and {(hasId ? "has Id" : "does not have Id")}");
            }
        }

        private void DoDelete(ICRMEvent context, Guid pluginStepId, mwo_PluginStepRegistration subject)
        {
            subject.mwo_ImageType = mwo_imagetype.None;
            DoManageImage(context, pluginStepId, subject);

            StepManager.Delete(pluginStepId);
            Tracer.Trace($"Deleted PluginStep: {pluginStepId}");
        }

        private void DoManageStage(ICRMEvent context, Guid pluginStepId, mwo_PluginStepRegistration subject)
        {
            if (subject.statecode == mwo_PluginStepRegistrationState.Active)
            {
                StepManager.Activate(pluginStepId);
                Tracer.Trace($"Activated PluginStep: {pluginStepId}");
            }
            else
            {
                StepManager.Deactivate(pluginStepId);
                Tracer.Trace($"Deactivated PluginStep: {pluginStepId}");
            }
        }

        private void DoUpdate(ICRMEvent context, Guid pluginStepId, mwo_PluginStepRegistration subject)
        {
            StepManager.Update(
                                pluginStepId,
                                subject.mwo_EventHandler,
                                MapPluginType(subject.mwo_EventHandlerType),
                                subject.mwo_Name,
                                subject.mwo_SDKMessage,
                                subject.mwo_PrimaryEntity,
                                subject.mwo_SecondaryEntity,
                                subject.mwo_StepConfiguration,
                                subject.mwo_Asynchronous == true,
                                MapStage(subject.mwo_PluginStepStage),
                                subject.mwo_FilteringAttributes,
                                subject.mwo_Description,
                                subject.mwo_Rank,
                                subject.mwo_AsyncAutoDelete);

            Tracer.Trace($"Updated PluginStep: {pluginStepId}");

            DoManageImage(context, pluginStepId, subject);
        }

        private void DoCreate(ICRMEvent context, mwo_PluginStepRegistration subject)
        {
            var res = StepManager.Register(
                subject.mwo_EventHandler,
                MapPluginType(subject.mwo_EventHandlerType),
                subject.mwo_Name,
                subject.mwo_SDKMessage,
                subject.mwo_PrimaryEntity,
                subject.mwo_SecondaryEntity,
                subject.mwo_StepConfiguration,
                subject.mwo_Asynchronous == true,
                MapStage(subject.mwo_PluginStepStage),
                subject.mwo_FilteringAttributes,
                subject.mwo_Description,
                subject.mwo_Rank,
                subject.mwo_AsyncAutoDelete);

            Tracer.Trace($"Created new PluginStep: {res}");
            subject.mwo_PluginStepId = res.ToString();

            DoManageImage(context, res, subject);
        }

        private void DoManageImage(ICRMEvent context, Guid pluginStepId, mwo_PluginStepRegistration subject)
        {
            if (subject.mwo_ImageType != null && subject.mwo_ImageType != mwo_imagetype.None)
            {
                ImageManager.Upsert(MapImageType(subject.mwo_ImageType), subject.mwo_ImageName, new EntityReference(SdkMessageProcessingStep.EntityLogicalName, pluginStepId), subject.mwo_ImageAttributes);
                Tracer.Trace($"Upserted image: {subject.mwo_ImageName}");
            }
            else
            {
                ImageManager.Delete(new EntityReference(SdkMessageProcessingStep.EntityLogicalName, pluginStepId));
                Tracer.Trace($"Deleted image: {subject.mwo_ImageName}");
            }
        }

        private static ImageType MapImageType(mwo_imagetype? imageType)
        {
            switch (imageType)
            {
                case mwo_imagetype.PreImage: return ImageType.PreImage;
                case mwo_imagetype.PostImage: return ImageType.PostImage;
                case mwo_imagetype.Both: return ImageType.Both;
                default: return ImageType.None;
            }
        }

        private static EventHandlerType MapPluginType(mwo_eventhandlertype? handlerType)
        {
            switch (handlerType)
            {
                case mwo_eventhandlertype.PluginType: return EventHandlerType.PluginType;
                case mwo_eventhandlertype.ServiceEndpoint: return EventHandlerType.ServiceEndpoint;
                default: return EventHandlerType.PluginType;
            }
        }

        private static StageEnum MapStage(mwo_pluginstage? stage)
        {
            switch (stage)
            {
                case mwo_pluginstage.PreValidation: return StageEnum.PreValidation;
                case mwo_pluginstage.PreOperation: return StageEnum.PreOperation;
                case mwo_pluginstage.PostOperation: return StageEnum.PostOperation;
                default: return StageEnum.PreOperation;
            }
        }
    }
}
