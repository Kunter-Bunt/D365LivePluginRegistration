using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;
using System.ServiceModel;

namespace mwo.LiveRegistration.Plugins.Tests.Helpers
{
    [TestClass]
    public class ImageManagerTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private ImageManager ImageManager;
        private const string ImageName = nameof(ImageName);
        private const string Attributes = nameof(Attributes);
        private const ImageTypeEnum TypeEnum = ImageTypeEnum.Both;
        private Entity MessageProccessingStep;

        [TestInitialize]
        public void Initialize()
        {
            Context = new XrmFakedContext();
            Service = Context.GetOrganizationService();
            ImageManager = new ImageManager(Service);

            MessageProccessingStep = new Entity("sdkmessageprocessingstep") { ["name"] = "Something" };
            MessageProccessingStep.Id = Service.Create(MessageProccessingStep);
        }

        [TestMethod]
        public void Upsert_CreateTest()
        {
            //Act
            ImageManager.Upsert(TypeEnum, ImageName, MessageProccessingStep.ToEntityReference(), null);

            //Assert
            var results = Context.CreateQuery("sdkmessageprocessingstepimage").ToList();
            Assert.AreEqual(1, results.Count);

            var result = results.First();
            Assert.AreEqual(MessageProccessingStep.Id, result.GetAttributeValue<EntityReference>("sdkmessageprocessingstepid").Id);
            Assert.AreEqual(2, result.GetAttributeValue<OptionSetValue>("imagetype").Value);
            Assert.AreEqual(ImageName, result.GetAttributeValue<string>("name"));
            Assert.AreEqual("Target", result.GetAttributeValue<string>("messagepropertyname"));
        }

        [TestMethod]
        public void Upsert_UpdateTest()
        {
            //Arrange
            Upsert_CreateTest();

            //Act
            ImageManager.Upsert(TypeEnum, ImageName, MessageProccessingStep.ToEntityReference(), Attributes);

            //Assert
            var results = Context.CreateQuery("sdkmessageprocessingstepimage").ToList();
            Assert.AreEqual(1, results.Count);

            var result = results.First();
            Assert.AreEqual(Attributes, result.GetAttributeValue<string>("attributes"));
        }

        [TestMethod]
        public void Delete_NoMoreImageTest()
        {
            //Arrange
            Upsert_CreateTest();

            //Act
            ImageManager.Delete(ImageName, MessageProccessingStep.ToEntityReference());

            //Assert
            var results = Context.CreateQuery("sdkmessageprocessingstepimage").ToList();
            Assert.AreEqual(0, results.Count);
        }
    }
}