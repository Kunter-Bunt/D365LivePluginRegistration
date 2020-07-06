using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.EntryPoints;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Tests.EntryPoints
{
    [TestClass]
    public class PostOpLiveRegistrationTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private const string PluginTypeName = "abc.xyz";
        private const string PrimaryEntityName = "lead";
        private const string Create = nameof(Create);
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

            PluginType = new Entity("plugintype") { ["typename"] = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            MessageCreate = new Entity("sdkmessage") { ["name"] = Create };
            MessageCreate.Id = Service.Create(MessageCreate);

            MessageFilterCreate = new Entity("sdkmessagefilter") { ["sdkmessageid"] = MessageCreate.ToEntityReference(), ["primaryobjecttypecode"] = PrimaryEntityName };
            MessageFilterCreate.Id = Service.Create(MessageFilterCreate);
        }

        [TestMethod]
        public void Create_StepCreatedTest()
        {
            //Arrange
            var target = new Entity("mwo_pluginstepregistration")
            {
                ["mwo_plugintypename"] = PluginTypeName,
                ["mwo_sdkmessage"] = Create,
                ["mwo_primaryentity"] = PrimaryEntityName,
                ["mwo_secondaryentity"] = null,
                ["mwo_stepconfiguration"] = null,
                ["mwo_asynchronous"] = true,
                ["mwwo_pluginstepstage"] = new OptionSetValue(122870040),
                ["mwo_filteringattributes"] = null,
                ["mwo_description"] = null,
                ["mwo_managed"] = true,
            };
            
            var ctx = CreateContext(target, null, "Create");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            Assert.AreNotEqual(Guid.Empty, target.GetAttributeValue<Guid>("mwo_pluginstepid"));

            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);

            target.Id = Service.Create(target); //This is here for the other tests that rely on the Entity being there.
        }

        [TestMethod]
        public void Update_ChangePersistsTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var desc = "newDesc";
            var target = new Entity("mwo_pluginstepregistration", preImage.Id)
            {
                ["mwo_description"] = desc,
            };
            var ctx = CreateContext(target, preImage, "Update");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(desc, steps.First().GetAttributeValue<string>("description"));
        }

        [TestMethod]
        public void Update_DeactivateTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var target = new Entity("mwo_pluginstepregistration", preImage.Id)
            {
                ["statecode"] = new OptionSetValue(1),
            };
            var ctx = CreateContext(target, preImage, "Update");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(1, steps.First().GetAttributeValue<OptionSetValue>("statecode").Value);
        }

        [TestMethod]
        public void Update_ActivateTest()
        {
            //Arrange
            Update_DeactivateTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var target = new Entity("mwo_pluginstepregistration", preImage.Id)
            {
                ["statecode"] = new OptionSetValue(0),
            };
            var ctx = CreateContext(target, preImage, "Update");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(0, steps.First().GetAttributeValue<OptionSetValue>("statecode").Value);
        }


        [TestMethod]
        public void Delete_NoMoreStepTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var target = new Entity("mwo_pluginstepregistration", preImage.Id);
            var ctx = CreateContext(target, preImage, "Delete");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(0, steps.Count);
        }

        [TestMethod]
        public void Delete_NotManagedTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var target = new Entity("mwo_pluginstepregistration", preImage.Id)
            {
                ["mwo_managed"] = false
            };
            var ctx = CreateContext(target, preImage, "Delete");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);
        }


        [TestMethod]
        public void Retrieve_IgnoreMessagesTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var target = new Entity("mwo_pluginstepregistration", preImage.Id);
            var ctx = CreateContext(target, preImage, "Retrieve");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery("sdkmessageprocessingstep").ToList();
            Assert.AreEqual(1, steps.Count);
        }

        private XrmFakedPluginExecutionContext CreateContext(Entity target, Entity preImage, string messagename)
        {
            var ctx = Context.GetDefaultPluginContext();
            ctx.InputParameters.Add("Target", target);
            if (preImage != null) ctx.PreEntityImages.Add("Default", preImage);
            ctx.MessageName = messagename;
            return ctx;
        }
    }
}