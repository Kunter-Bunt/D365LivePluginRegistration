﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;

namespace mwo.LiveRegistration.Plugins.Extensions.Tests
{
    [TestClass()]
    public class EntityExtensionsTests
    {
        [TestMethod()]
        public void MergeTest()
        {
            //Arrange
            var baseEnt = new Entity("account", Guid.NewGuid()) { ["name"] = "baseEnt" };
            var additionalEnt = new Entity("account", Guid.NewGuid()) { ["name"] = "additionalEnt" };

            //Act
            var mergedEnt = baseEnt.Merge(additionalEnt);

            //Assert
            Assert.AreEqual(baseEnt.Id, mergedEnt.Id);
            Assert.AreEqual(additionalEnt["name"], mergedEnt["name"]);
        }
    }
}