using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.EntryPoints;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Tests.EntryPoints
{
    [TestClass]
    public class PreOpLiveRegistrationTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private const string PluginTypeName = "abc.xyz";
        private const string PrimaryEntityName = "lead";
        private const string Create = nameof(Create);
        private const string Update = nameof(Update);
        private const string Delete = nameof(Delete);
        private const string Associate = nameof(Associate);
        private const string GlobalAction = nameof(GlobalAction);
        private const string Description = nameof(Description);
        private Entity PluginType;
        private Entity MessageCreate;
        private Entity MessageFilterCreate;

        [TestInitialize]
        public void Initialize()
        {
            Context = new XrmFakedContext();
            Service = Context.GetOrganizationService();

            PluginType = new PluginType { TypeName = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            MessageCreate = new SdkMessage { Name = Create };
            MessageCreate.Id = Service.Create(MessageCreate);

            MessageFilterCreate = new SdkMessageFilter { SdkMessageId = MessageCreate.ToEntityReference(), ["primaryobjecttypecode"] = PrimaryEntityName };
            MessageFilterCreate.Id = Service.Create(MessageFilterCreate);
        }

        [TestMethod]
        public void Create_StepCreatedTest()
        {
            //Arrange
            var target = new mwo_PluginStepRegistration
            {
                mwo_EventHandler = PluginTypeName,
                mwo_EventHandlerType = mwo_eventhandlertype.PluginType,
                mwo_SDKMessage = Create,
                mwo_PrimaryEntity = PrimaryEntityName,
                mwo_SecondaryEntity = null,
                mwo_StepConfiguration = null,
                mwo_Asynchronous = true,
                mwo_PluginStepStage = mwo_pluginstage.PostOperation,
                mwo_FilteringAttributes = null,
                mwo_Description = null,
                mwo_Managed = null,
                mwo_ImageType = null
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            Assert.IsNotNull(target.mwo_PluginStepId);

            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(1, steps.First().Rank);
            Assert.IsTrue(steps.First().AsyncAutoDelete.Value);

            target.Id = Service.Create(target); //This is here for the other tests that rely on the Entity being there.
        }

        [TestMethod]
        public void Create_StepCreatedTest_ExecutionOrder()
        {
            //Arrange
            var target = new mwo_PluginStepRegistration
            {
                mwo_EventHandler = PluginTypeName,
                mwo_EventHandlerType = mwo_eventhandlertype.PluginType,
                mwo_SDKMessage = Create,
                mwo_PrimaryEntity = PrimaryEntityName,
                mwo_SecondaryEntity = null,
                mwo_StepConfiguration = null,
                mwo_Asynchronous = true,
                mwo_PluginStepStage = mwo_pluginstage.PostOperation,
                mwo_FilteringAttributes = null,
                mwo_Description = null,
                mwo_Managed = null,
                mwo_ImageType = null,
                mwo_Rank = 5,
                mwo_AsyncAutoDelete = false,
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            Assert.IsNotNull(target.mwo_PluginStepId);

            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(5, steps.First().Rank);
            Assert.IsFalse(steps.First().AsyncAutoDelete.Value);

            target.Id = Service.Create(target); //This is here for the other tests that rely on the Entity being there.
        }

        [TestMethod]
        public void Create_ImageCreatedTest()
        {
            //Arrange
            var target = new mwo_PluginStepRegistration
            {
                mwo_EventHandler = PluginTypeName,
                mwo_EventHandlerType = mwo_eventhandlertype.PluginType,
                mwo_SDKMessage = Create,
                mwo_PrimaryEntity = PrimaryEntityName,
                mwo_SecondaryEntity = null,
                mwo_StepConfiguration = null,
                mwo_Asynchronous = true,
                mwo_PluginStepStage = mwo_pluginstage.PostOperation,
                mwo_FilteringAttributes = null,
                mwo_Description = null,
                mwo_Managed = true,
                mwo_ImageType = mwo_imagetype.Both,
                mwo_ImageName = "Default",
                mwo_ImageAttributes = null
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);

            target.Id = Service.Create(target); //This is here for the other tests that rely on the Entity being there.
        }

        [TestMethod]
        public void Update_ChangePersistsTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var desc = "newDesc";
            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id,
                mwo_Description = desc,
            };
            var ctx = CreateContext(target, preImage, Update);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(desc, steps.First().Description);
        }

        [TestMethod]
        public void Update_ChangeExecutionOrderTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var order = 8;
            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id,
                mwo_Rank = order,
            };
            var ctx = CreateContext(target, preImage, Update);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(order, steps.First().Rank);
        }

        [TestMethod]
        public void Update_ImageChangeTest()
        {
            //Arrange
            Create_ImageCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var name = "newName";
            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id,
                mwo_ImageName = name
            };
            var ctx = CreateContext(target, preImage, Update);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStepImage>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(name, steps.First().EntityAlias);
        }

        [TestMethod]
        public void Update_DeactivateTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id,
                statecode = mwo_PluginStepRegistrationState.Inactive,
            };
            var ctx = CreateContext(target, preImage, Update);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(SdkMessageProcessingStepState.Disabled, steps.First().StateCode);
        }

        [TestMethod]
        public void Update_ActivateTest()
        {
            //Arrange
            Update_DeactivateTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id,
                statecode = mwo_PluginStepRegistrationState.Active,
            };
            var ctx = CreateContext(target, preImage, Update);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(SdkMessageProcessingStepState.Enabled, steps.First().StateCode);
        }


        [TestMethod]
        public void Delete_NoMoreStepTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id
            };
            var ctx = CreateContext(target, preImage, Delete);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(0, steps.Count);
        }

        [TestMethod]
        public void Delete_NoMoreImageTest()
        {
            //Arrange
            Create_ImageCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var ctx = CreateContext(preImage.ToEntityReference(), preImage, Delete);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var images = Context.CreateQuery<SdkMessageProcessingStepImage>().ToList();
            Assert.AreEqual(0, images.Count);
        }

        [TestMethod]
        public void Delete_NotManagedTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();
            preImage.mwo_Managed = false;

            var ctx = CreateContext(preImage.ToEntityReference(), preImage, Delete);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Delete_NoTargetTest()
        {
            //Arrange
            var ctx = CreateContext(null, null, Delete);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Delete_NoMessageTest()
        {
            //Arrange
            var ctx = CreateContext(new mwo_PluginStepRegistration() { mwo_Managed = true }, null, null);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);
        }

        [TestMethod]
        public void Retrieve_IgnoreMessagesTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery<mwo_PluginStepRegistration>().First();

            var target = new mwo_PluginStepRegistration()
            {
                Id = preImage.Id
            };
            var ctx = CreateContext(target, preImage, "Retrieve");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery<SdkMessageProcessingStep>().ToList();
            Assert.AreEqual(1, steps.Count);
        }


        private XrmFakedPluginExecutionContext CreateContext(object target, Entity preImage, string messagename)
        {
            var ctx = Context.GetDefaultPluginContext();
            ctx.InputParameters.Add("Target", target);
            if (preImage != null) ctx.PreEntityImages.Add("Default", preImage);
            ctx.MessageName = messagename;
            return ctx;
        }
    }
}