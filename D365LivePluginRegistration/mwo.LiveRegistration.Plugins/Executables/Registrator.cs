using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;

namespace mwo.LiveRegistration.Plugins.Executables
{
    class Registrator : ICRMExecutable
    {
        private IPluginStepRegistrationManager StepManager { get; set; }
        private IImageManager ImageManager { get; set; }

        public Registrator(IOrganizationService service)
        {
            StepManager = new PluginStepRegistrationManager(service);
            ImageManager = new ImageManager(service);
        }

        public void Execute(IContext context)
        {
            if (!context.Subject.GetAttributeValue<bool>(PluginRegistration.Managed)) return;

            var msg = context.PluginExecutionContext.MessageName.ToUpperInvariant();
            var pluginStepId = Guid.Empty;
            var hasId = context.Subject.Contains(PluginRegistration.Pluginstepid) && Guid.TryParse(context.Subject.GetAttributeValue<string>(PluginRegistration.Pluginstepid), out pluginStepId);
            if (msg == Messages.Delete && hasId)
            {
                DoDelete(context, pluginStepId);
            }
            else if (msg == Messages.Update && hasId)
            {
                DoUpdate(context, pluginStepId);
                if (context.Target.Contains(PluginRegistration.Statecode))
                    DoManageStage(context, pluginStepId);
            }
            else if ((msg == Messages.Update || msg == Messages.Create) && !hasId)
            {
                DoCreate(context);
            }
            else
            {
                context.Tracer.Trace($"Nothing to do for {msg} and {(hasId ? "has Id" : "does not have Id")}");
            }
        }

        private void DoDelete(IContext context, Guid pluginStepId)
        {
            context.Subject[PluginRegistration.Imagetype] = new OptionSetValue(PluginRegistration.ImagetypeNone); //Pass Image none, as we are going to delete.
            DoManageImage(context, pluginStepId);

            StepManager.Delete(pluginStepId);
            context.Tracer.Trace($"Deleted PluginStep: {pluginStepId}");
        }

        private void DoManageStage(IContext context, Guid pluginStepId)
        {
            var state = context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Statecode);
            if (state.Value == PluginRegistration.StatecodeActive)
            {
                StepManager.Activate(pluginStepId);
                context.Tracer.Trace($"Activated PluginStep: {pluginStepId}");
            }
            else
            {
                StepManager.Deactivate(pluginStepId);
                context.Tracer.Trace($"Deactivated PluginStep: {pluginStepId}");
            }
        }

        private void DoUpdate(IContext context, Guid pluginStepId)
        {
            StepManager.Update(
                                pluginStepId,
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Plugintypename),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Sdkmessage),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Primaryentity),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Secondaryentity),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Stepconfiguration),
                                context.Subject.GetAttributeValue<bool>(PluginRegistration.Asynchronous),
                                MapStage(context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Pluginstepstage)),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Filteringattributes),
                                context.Subject.GetAttributeValue<string>(PluginRegistration.Description));

            context.Tracer.Trace($"Updated PluginStep: {pluginStepId}");

            DoManageImage(context, pluginStepId);
        }

        private void DoCreate(IContext context)
        {
            var res = StepManager.Register(
                context.Subject.GetAttributeValue<string>(PluginRegistration.Plugintypename),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Sdkmessage),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Primaryentity),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Secondaryentity),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Stepconfiguration),
                context.Subject.GetAttributeValue<bool>(PluginRegistration.Asynchronous),
                MapStage(context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Pluginstepstage)),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Filteringattributes),
                context.Subject.GetAttributeValue<string>(PluginRegistration.Description));

            context.Tracer.Trace($"Created new PluginStep: {res}");
            context.Subject[PluginRegistration.Pluginstepid] = res.ToString();

            DoManageImage(context, res);
        }

        private void DoManageImage(IContext context, Guid pluginStepId)
        {
            if (context.Subject.Contains(PluginRegistration.Imagetype) && context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Imagetype) != null && context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Imagetype).Value != PluginRegistration.ImagetypeNone)
            {
                ImageManager.Upsert(MapImageType(context.Subject.GetAttributeValue<OptionSetValue>(PluginRegistration.Imagetype)), context.Subject.GetAttributeValue<string>(PluginRegistration.Imagename), new EntityReference(Sdkmessageprocessingstep.LogicalName, pluginStepId), context.Subject.GetAttributeValue<string>(PluginRegistration.ImageAttributes));
                context.Tracer.Trace($"Upserted image: {context.Subject.GetAttributeValue<string>(PluginRegistration.Imagename)}");
            }
            else
            {
                ImageManager.Delete(new EntityReference(Sdkmessageprocessingstep.LogicalName, pluginStepId));
                context.Tracer.Trace($"Deleted image: {context.Subject.GetAttributeValue<string>(PluginRegistration.Imagename)}");
            }
        }

        private static Stage MapStage(OptionSetValue optionSetValue)
        {
            return (Stage)(optionSetValue.Value - PluginRegistration.EnumPrefix); // Values were created to match stages!
        }

        private static ImageType MapImageType(OptionSetValue optionSetValue)
        {
            return (ImageType)(optionSetValue.Value - PluginRegistration.EnumPrefix); // Values were created to match types!
        }
    }
}
