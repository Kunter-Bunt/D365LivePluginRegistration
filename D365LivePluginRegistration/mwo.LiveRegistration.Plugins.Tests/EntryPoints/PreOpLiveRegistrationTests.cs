﻿using FakeXrmEasy;
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

            PluginType = new Entity(Plugintype.LogicalName) { [Plugintype.Typename] = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            MessageCreate = new Entity(Sdkmessage.LogicalName) { [Sdkmessage.Name] = Create };
            MessageCreate.Id = Service.Create(MessageCreate);

            MessageFilterCreate = new Entity(Sdkmessagefilter.LogicalName) { [Sdkmessagefilter.Sdkmessageid] = MessageCreate.ToEntityReference(), [Sdkmessagefilter.Primaryobjecttypecode] = PrimaryEntityName };
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
                ["mwo_pluginstepstage"] = new OptionSetValue(122870040),
                ["mwo_filteringattributes"] = null,
                ["mwo_description"] = null,
                ["mwo_managed"] = true,
                ["mwo_imagetype"] = null,
            };
            
            var ctx = CreateContext(target, null, "Create");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            Assert.IsNotNull(target.GetAttributeValue<string>("mwo_pluginstepid"));

            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);

            target.Id = Service.Create(target); //This is here for the other tests that rely on the Entity being there.
        }

        [TestMethod]
        public void Create_ImageCreatedTest()
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
                ["mwo_pluginstepstage"] = new OptionSetValue(122870040),
                ["mwo_filteringattributes"] = null,
                ["mwo_description"] = null,
                ["mwo_managed"] = true,
                ["mwo_imagetype"] = new OptionSetValue(122870002),
                ["mwo_imagename"] = "Default",
                ["mwo_imageattributes"] = null,
            };

            var ctx = CreateContext(target, null, "Create");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
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
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(desc, steps.First().GetAttributeValue<string>(Sdkmessageprocessingstep.Description));
        }

        [TestMethod]
        public void Update_ImageChangeTest()
        {
            //Arrange
            Create_ImageCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var name = "newName";
            var target = new Entity("mwo_pluginstepregistration", preImage.Id)
            {
                ["mwo_imagename"] = name,
            };
            var ctx = CreateContext(target, preImage, "Update");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery(Sdkmessageprocessingstepimage.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(name, steps.First().GetAttributeValue<string>(Sdkmessageprocessingstepimage.Entityalias));
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
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(1, steps.First().GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Statecode).Value);
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
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);
            Assert.AreEqual(0, steps.First().GetAttributeValue<OptionSetValue>(Sdkmessageprocessingstep.Statecode).Value);
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
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(0, steps.Count);
        }

        [TestMethod]
        public void Delete_NoMoreImageTest()
        {
            //Arrange
            Create_ImageCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();

            var ctx = CreateContext(preImage.ToEntityReference(), preImage, "Delete");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var images = Context.CreateQuery(Sdkmessageprocessingstepimage.LogicalName).ToList();
            Assert.AreEqual(0, images.Count);
        }

        [TestMethod]
        public void Delete_NotManagedTest()
        {
            //Arrange
            Create_StepCreatedTest();
            var preImage = Context.CreateQuery("mwo_pluginstepregistration").First();
            preImage["mwo_managed"] = false;

            var ctx = CreateContext(preImage.ToEntityReference(), preImage, "Delete");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);

            //Assert
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
            Assert.AreEqual(1, steps.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Delete_NoTargetTest()
        {
            //Arrange
            var ctx = CreateContext(null, null, "Delete");

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Delete_NoMessageTest()
        {
            //Arrange
            var ctx = CreateContext(new Entity("mwo_pluginstepregistration") { ["mwo_managed"] = true }, null, null);

            //Act
            Context.ExecutePluginWith<PreOpLiveRegistration>(ctx);
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
            var steps = Context.CreateQuery(Sdkmessageprocessingstep.LogicalName).ToList();
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