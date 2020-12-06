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
    public class PreOpEventHandlerTests
    {
        private XrmFakedContext Context;
        private IOrganizationService Service;
        private const string PluginTypeName = "abc.xyz";
        private const string ServiceEndpointName = "(Service Endpoint) abc.xyz";
        private const string PrimaryEntityName = "lead";
        private const string Create = nameof(Create);
        private const string Update = nameof(Update);
        private const string Delete = nameof(Delete);
        private const string Associate = nameof(Associate);
        private const string GlobalAction = nameof(GlobalAction);
        private const string Description = nameof(Description);
        private Entity PluginType;
        private Entity Endpoint;

        [TestInitialize]
        public void Initialize()
        {
            Context = new XrmFakedContext();
            Service = Context.GetOrganizationService();

            PluginType = new Entity(Plugintype.LogicalName) { [Plugintype.Typename] = PluginTypeName };
            PluginType.Id = Service.Create(PluginType);

            Endpoint = new Entity(ServiceEndpoint.LogicalName) { [ServiceEndpoint.Name] = ServiceEndpointName };
            Endpoint.Id = Service.Create(Endpoint);
        }

        [TestMethod]
        public void Create_PluginTypeTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = PluginTypeName,
                [PluginEventHandler.Type] = 122870000.ToOptionSetValue(),
            };
            
            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);

            //Assert
            Assert.AreEqual(PluginType.Id.ToString(), target.GetAttributeValue<string>(PluginEventHandler.CrmEventHandlerId));
            Assert.AreEqual(PluginType.LogicalName, target.GetAttributeValue<string>(PluginEventHandler.TypeLogicalName));
        }

        [TestMethod]
        public void Create_ServiceEndpointTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = ServiceEndpointName,
                [PluginEventHandler.Type] = 122870001.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);

            //Assert
            Assert.AreEqual(Endpoint.Id.ToString(), target.GetAttributeValue<string>(PluginEventHandler.CrmEventHandlerId));
            Assert.AreEqual(Endpoint.LogicalName, target.GetAttributeValue<string>(PluginEventHandler.TypeLogicalName));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_WrongTypeTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = PluginTypeName,
                [PluginEventHandler.Type] = 122870001.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_PluginTypeFailureTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = "Nope",
                [PluginEventHandler.Type] = 122870000.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_ServiceEndpointFailureTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = "Nope",
                [PluginEventHandler.Type] = 122870001.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_NoTypeTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = PluginTypeName,
                [PluginEventHandler.Type] = null,
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_NoNameTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = null,
                [PluginEventHandler.Type] = 122870001.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException))]
        public void Create_UnknownTypeTest()
        {
            //Arrange
            var target = new Entity(PluginEventHandler.LogicalName)
            {
                [PluginEventHandler.Name] = "Nope",
                [PluginEventHandler.Type] = 122870009.ToOptionSetValue(),
            };

            var ctx = CreateContext(target, null, Create);

            //Act
            Context.ExecutePluginWith<PreOpEventHandler>(ctx);
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