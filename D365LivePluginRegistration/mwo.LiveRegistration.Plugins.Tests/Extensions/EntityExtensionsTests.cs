using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Extensions;
using System;

namespace mwo.LiveRegistration.Plugins.Tests.Extensions
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

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoAdditonalTest()
        {
            //Arrange
            var baseEnt = new Entity("account", Guid.NewGuid()) { ["name"] = "baseEnt" };

            //Act
            baseEnt.Merge(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NobaseTest()
        {
            //Arrange
            Entity baseEnt = null;
            var additionalEnt = new Entity("account", Guid.NewGuid()) { ["name"] = "additionalEnt" };

            //Act
            baseEnt.Merge(additionalEnt);
        }
    }
}