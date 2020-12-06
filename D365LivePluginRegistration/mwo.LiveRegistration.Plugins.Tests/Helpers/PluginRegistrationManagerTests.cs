using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.ServiceModel;

namespace mwo.LiveRegistration.Plugins.Tests.Helpers
{
    [TestClass]
    public class PluginRegistrationManagerTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private IPluginStepRegistrationManager PluginManager;
        private const string PluginTypeName = "abc.xyz";
        private const string StepName = "abc.xyz_Create";
        private const string PrimaryEntityName = "lead";
        private const string SecondaryEntityName = "account";
        private const string Create = nameof(Create);
        private const string Associate = nameof(Associate);
        private const string GlobalAction = nameof(GlobalAction);
        private const string Description = nameof(Description);
        private Entity EventHandler;
        private Entity PluginType;
        private Entity MessageCreate;
        private Entity MessageAssociate;
        private Entity MessageGlobalAction;
        private Entity MessageFilterCreate;
        private Entity MessageFilterAssociate;
        private Entity MessageProccessingStep;

        [TestInitialize]
        public void Initialize()
        {
            Context = new XrmFakedContext();
            Service = Context.GetOrganizationService();
            PluginManager = new PluginStepRegistrationManager(Service);

            PluginType = new Entity(Plugintype.LogicalName) { [Plugintype.Typename] = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            EventHandler = new Entity(PluginEventHandler.LogicalName) { [PluginEventHandler.TypeLogicalName] = Plugintype.LogicalName, [PluginEventHandler.CrmEventHandlerId] = PluginType.Id.ToString(), };
            EventHandler.Id = Service.Create(EventHandler);

            MessageCreate = new Entity(Sdkmessage.LogicalName) { [Sdkmessage.Name] = Create };
            MessageCreate.Id = Service.Create(MessageCreate);

            MessageAssociate = new Entity(Sdkmessage.LogicalName) { [Sdkmessage.Name] = Associate };
            MessageAssociate.Id = Service.Create(MessageAssociate);

            MessageGlobalAction = new Entity(Sdkmessage.LogicalName) { [Sdkmessage.Name] = GlobalAction };
            MessageGlobalAction.Id = Service.Create(MessageGlobalAction);

            MessageFilterCreate = new Entity(Sdkmessagefilter.LogicalName) { [Sdkmessagefilter.Sdkmessageid] = MessageCreate.ToEntityReference(), [Sdkmessagefilter.Primaryobjecttypecode] = PrimaryEntityName };
            MessageFilterCreate.Id = Service.Create(MessageFilterCreate);

            MessageFilterAssociate = new Entity(Sdkmessagefilter.LogicalName) { [Sdkmessagefilter.Sdkmessageid] = MessageAssociate.ToEntityReference(), [Sdkmessagefilter.Primaryobjecttypecode] = PrimaryEntityName, [Sdkmessagefilter.Secondaryobjecttypecode] = SecondaryEntityName };
            MessageFilterAssociate.Id = Service.Create(MessageFilterAssociate);

            MessageProccessingStep = new Entity(Sdkmessageprocessingstep.LogicalName) { [Sdkmessageprocessingstep.Name] = "Something" };
            MessageProccessingStep.Id = Service.Create(MessageProccessingStep);
        }

        [TestMethod]
        public void Register_CreateLeadTest()
        {
            //Act
            var id = PluginManager.Register(EventHandler.ToEntityReference(), StepName, Create, PrimaryEntityName, null, null, true, Stage.PostOperation, null, Description);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, id, new ColumnSet(true));
            Assert.AreEqual(MessageFilterCreate.Id, result.GetAttributeValue<EntityReference>(Sdkmessageprocessingstep.Sdkmessagefilterid).Id);
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Mode).Value);
            Assert.AreEqual((int)Stage.PostOperation, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Stage).Value);
        }

        [TestMethod]
        public void Register_AssociateLeadAccountTest()
        {
            //Act
            var id = PluginManager.Register(EventHandler.ToEntityReference(), StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, Stage.PostOperation, null, null);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, id, new ColumnSet(true));
            Assert.AreEqual(MessageFilterAssociate.Id, result.GetAttributeValue<EntityReference>(Sdkmessageprocessingstep.Sdkmessagefilterid).Id);
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Mode).Value);
            Assert.AreEqual((int)Stage.PostOperation, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Stage).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Register_MessageNotExisitingTest()
        {
            //Act
            PluginManager.Register(EventHandler.ToEntityReference(), StepName, "Nope", PrimaryEntityName, null, null, true, Stage.PostOperation, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_PluginNotExisitingTest()
        {
            //Act
            PluginManager.Register(null, StepName, Create, PrimaryEntityName, null, null, true, Stage.PostOperation, null, null);
        }

        [TestMethod]
        public void Register_GlobalActionTest()
        {
            //Act
            var id = PluginManager.Register(EventHandler.ToEntityReference(), StepName, GlobalAction, null, null, null, false, Stage.PreOperation, null, null);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, id, new ColumnSet(true));
            Assert.AreEqual(0, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Mode).Value);
            Assert.IsNull(result.GetAttributeValue<EntityReference>(Sdkmessageprocessingstep.Sdkmessagefilterid));
            Assert.AreEqual(MessageGlobalAction.Id, result.GetAttributeValue<EntityReference>(Sdkmessageprocessingstep.Sdkmessageid).Id);
            Assert.AreEqual((int)Stage.PreOperation, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Stage).Value);
        }

        [TestMethod]
        public void Register_NameDescTest()
        {
            //Act
            var id = PluginManager.Register(EventHandler.ToEntityReference(), StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, Stage.PostOperation, null, Description);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, id, new ColumnSet(true));
            Assert.AreEqual(StepName, result.GetAttributeValue<string>(Sdkmessageprocessingstep.Name));
            Assert.AreEqual(Description, result.GetAttributeValue<string>(Sdkmessageprocessingstep.Description));
        }


        [TestMethod]
        public void Update_NameDescTest()
        {
            //Act
            PluginManager.Update(MessageProccessingStep.Id, EventHandler.ToEntityReference(), StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, Stage.PostOperation, null, Description);

            //Assert
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(StepName, result.GetAttributeValue<string>(Sdkmessageprocessingstep.Name));
            Assert.AreEqual(Description, result.GetAttributeValue<string>(Sdkmessageprocessingstep.Description));
        }

        [TestMethod]
        public void Activate_Test()
        {
            //Arrange
            PluginManager.Deactivate(MessageProccessingStep.Id);

            //Act
            PluginManager.Activate(MessageProccessingStep.Id);

            //Assert
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(0, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Statecode).Value);
        }

        [TestMethod]
        public void Deactivate_Test()
        {
            //Act
            PluginManager.Deactivate(MessageProccessingStep.Id);

            //Assert
            var result = Service.Retrieve(Sdkmessageprocessingstep.LogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Statecode).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OrganizationServiceFault>))]
        public void Delete_Test()
        {
            //Act
            PluginManager.Delete(MessageProccessingStep.Id);

            //Assert
            Service.Retrieve(Sdkmessageprocessingstep.LogicalName, MessageProccessingStep.Id, new ColumnSet(true));
        }
    }
}