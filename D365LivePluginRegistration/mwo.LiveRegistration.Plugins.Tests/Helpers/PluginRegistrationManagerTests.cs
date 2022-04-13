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

            PluginType = new PluginType{ TypeName = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            MessageCreate = new SdkMessage { Name = Create };
            MessageCreate.Id = Service.Create(MessageCreate);

            MessageAssociate = new SdkMessage { Name = Associate };
            MessageAssociate.Id = Service.Create(MessageAssociate);

            MessageGlobalAction = new SdkMessage { Name = GlobalAction };
            MessageGlobalAction.Id = Service.Create(MessageGlobalAction);

            MessageFilterCreate = new SdkMessageFilter { SdkMessageId = MessageCreate.ToEntityReference(), ["primaryobjecttypecode"] = PrimaryEntityName };
            MessageFilterCreate.Id = Service.Create(MessageFilterCreate);

            MessageFilterAssociate = new SdkMessageFilter { SdkMessageId = MessageAssociate.ToEntityReference(), ["primaryobjecttypecode"] = PrimaryEntityName, ["secondaryobjecttypecode"] = SecondaryEntityName };
            MessageFilterAssociate.Id = Service.Create(MessageFilterAssociate);

            MessageProccessingStep = new SdkMessageProcessingStep { Name = "Something" };
            MessageProccessingStep.Id = Service.Create(MessageProccessingStep);
        }

        [TestMethod]
        public void Register_CreateLeadTest()
        {
            //Act
            var id = PluginManager.Register(PluginTypeName, EventHandlerType.PluginType, StepName, Create, PrimaryEntityName, null, null, true, StageEnum.PostOperation, null, Description);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, id, new ColumnSet(true));
            Assert.AreEqual(MessageFilterCreate.Id, result.GetAttributeValue<EntityReference>("sdkmessagefilterid").Id);
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>("mode").Value);
            Assert.AreEqual((int)StageEnum.PostOperation, result.GetAttributeValue<OptionSetValue>("stage").Value);
        }

        [TestMethod]
        public void Register_AssociateLeadAccountTest()
        {
            //Act
            var id = PluginManager.Register(PluginTypeName, EventHandlerType.PluginType, StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, StageEnum.PostOperation, null, null);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, id, new ColumnSet(true));
            Assert.AreEqual(MessageFilterAssociate.Id, result.GetAttributeValue<EntityReference>("sdkmessagefilterid").Id);
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>("mode").Value);
            Assert.AreEqual((int)StageEnum.PostOperation, result.GetAttributeValue<OptionSetValue>("stage").Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Register_MessageNotExisitingTest()
        {
            //Act
            PluginManager.Register(PluginTypeName, EventHandlerType.PluginType, StepName, "Nope", PrimaryEntityName, null, null, true, StageEnum.PostOperation, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Register_PluginNotExisitingTest()
        {
            //Act
            PluginManager.Register(null, EventHandlerType.PluginType, StepName, Create, PrimaryEntityName, null, null, true, StageEnum.PostOperation, null, null);
        }

        [TestMethod]
        public void Register_GlobalActionTest()
        {
            //Act
            var id = PluginManager.Register(PluginTypeName, EventHandlerType.PluginType, StepName, GlobalAction, null, null, null, false, StageEnum.PreOperation, null, null);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, id, new ColumnSet(true));
            Assert.AreEqual(0, result.GetAttributeValue<OptionSetValue>("mode").Value);
            Assert.IsNull(result.GetAttributeValue<EntityReference>("sdkmessagefilterid"));
            Assert.AreEqual(MessageGlobalAction.Id, result.GetAttributeValue<EntityReference>("sdkmessageid").Id);
            Assert.AreEqual((int)StageEnum.PreOperation, result.GetAttributeValue<OptionSetValue>("stage").Value);
        }

        [TestMethod]
        public void Register_NameDescTest()
        {
            //Act
            var id = PluginManager.Register(PluginTypeName, EventHandlerType.PluginType, StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, StageEnum.PostOperation, null, Description);

            //Assert
            Assert.AreNotEqual(Guid.Empty, id);
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, id, new ColumnSet(true));
            Assert.AreEqual(StepName, result.GetAttributeValue<string>("name"));
            Assert.AreEqual(Description, result.GetAttributeValue<string>("description"));
        }


        [TestMethod]
        public void Update_NameDescTest()
        {
            //Act
            PluginManager.Update(MessageProccessingStep.Id, PluginTypeName, EventHandlerType.PluginType, StepName, Associate, PrimaryEntityName, SecondaryEntityName, null, true, StageEnum.PostOperation, null, Description);

            //Assert
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(StepName, result.GetAttributeValue<string>("name"));
            Assert.AreEqual(Description, result.GetAttributeValue<string>("description"));
        }

        [TestMethod]
        public void Activate_Test()
        {
            //Arrange
            PluginManager.Deactivate(MessageProccessingStep.Id);

            //Act
            PluginManager.Activate(MessageProccessingStep.Id);

            //Assert
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(0, result.GetAttributeValue<OptionSetValue>("statecode").Value);
        }

        [TestMethod]
        public void Deactivate_Test()
        {
            //Act
            PluginManager.Deactivate(MessageProccessingStep.Id);

            //Assert
            var result = Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, MessageProccessingStep.Id, new ColumnSet(true));
            Assert.AreEqual(1, result.GetAttributeValue<OptionSetValue>("statecode").Value);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<OrganizationServiceFault>))]
        public void Delete_Test()
        {
            //Act
            PluginManager.Delete(MessageProccessingStep.Id);

            //Assert
            Service.Retrieve(SdkMessageProcessingStep.EntityLogicalName, MessageProccessingStep.Id, new ColumnSet(true));
        }
    }
}