﻿using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Helpers;
using mwo.LiveRegistration.Plugins.Interfaces;
using mwo.LiveRegistration.Plugins.Models;
using System;
using System.Linq;

namespace mwo.LiveRegistration.Plugins.Tests.Helpers
{
    [TestClass]
    public class ImageManagerTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private IImageManager ImageManager;
        private const string ImageName = nameof(ImageName);
        private const string Attributes = nameof(Attributes);
        private const ImageType TypeEnum = ImageType.Both;
        private Entity MessageProccessingStep;

        [TestInitialize]
        public void Initialize()
        {
            Context = new XrmFakedContext();
            Service = Context.GetOrganizationService();
            ImageManager = new ImageManager(Service);

            MessageProccessingStep = new SdkMessageProcessingStep { Name = "Something" };
            MessageProccessingStep.Id = Service.Create(MessageProccessingStep);
        }

        [TestMethod]
        public void Upsert_CreateTest()
        {
            //Act
            ImageManager.Upsert(TypeEnum, ImageName, MessageProccessingStep.ToEntityReference(), null);

            //Assert
            var results = Context.CreateQuery<SdkMessageProcessingStepImage>().ToList();
            Assert.AreEqual(1, results.Count);

            var result = results.First();
            Assert.AreEqual(MessageProccessingStep.Id, result.SdkMessageProcessingStepId.Id);
            Assert.AreEqual(sdkmessageprocessingstepimage_imagetype.Both, result.ImageType);
            Assert.AreEqual(ImageName, result.Name);
            Assert.AreEqual("Target", result.MessagePropertyName);
        }

        [TestMethod]
        public void Upsert_UpdateTest()
        {
            //Arrange
            Upsert_CreateTest();

            //Act
            ImageManager.Upsert(TypeEnum, ImageName, MessageProccessingStep.ToEntityReference(), Attributes);

            //Assert
            var results = Context.CreateQuery<SdkMessageProcessingStepImage>().ToList();
            Assert.AreEqual(1, results.Count);

            var result = results.First();
            Assert.AreEqual(Attributes, result.Attributes1);
        }

        [TestMethod]
        public void Upsert_NoNameTest()
        {
            //Act
            ImageManager.Upsert(TypeEnum, null, MessageProccessingStep.ToEntityReference(), Attributes);

            //Assert
            Assert.IsTrue(true); //No Error
        }

        [TestMethod]
        public void Upsert_NoStepTest()
        {
            //Act
            ImageManager.Upsert(TypeEnum, ImageName, null, Attributes);

            //Assert
            Assert.IsTrue(true); //No Error
        }

        [TestMethod]
        public void Delete_NoMoreImageTest()
        {
            //Arrange
            Upsert_CreateTest();

            //Act
            ImageManager.Delete(MessageProccessingStep.ToEntityReference());

            //Assert
            var results = Context.CreateQuery<SdkMessageProcessingStepImage>().ToList();
            Assert.AreEqual(0, results.Count);
        }


        [TestMethod]
        public void Delete_NoInputTest()
        {
            //Act
            ImageManager.Delete(null);

            //Assert
            Assert.IsTrue(true); //No Error
        }
    }
}