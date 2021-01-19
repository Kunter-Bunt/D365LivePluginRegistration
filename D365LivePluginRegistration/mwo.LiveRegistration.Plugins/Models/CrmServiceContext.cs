//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// Created via this command line: "C:\Users\mariu\AppData\Roaming\MscrmTools\XrmToolBox\Plugins\DLaB.EarlyBoundGenerator\crmsvcutil.exe" /namespace:"mwo.LiveRegistration.Plugins.Models" /SuppressGeneratedCodeAttribute /out:"C:\Users\mariu\source\repos\Kunter-Bunt\D365LivePluginRegistration\D365LivePluginRegistration\mwo.LiveRegistration.Plugins\Models\CrmServiceContext.cs" /servicecontextname:"CrmServiceContext" /codecustomization:"DLaB.CrmSvcUtilExtensions.Entity.CustomizeCodeDomService,DLaB.CrmSvcUtilExtensions" /codegenerationservice:"DLaB.CrmSvcUtilExtensions.Entity.CustomCodeGenerationService,DLaB.CrmSvcUtilExtensions" /codewriterfilter:"DLaB.CrmSvcUtilExtensions.Entity.CodeWriterFilterService,DLaB.CrmSvcUtilExtensions" /namingservice:"DLaB.CrmSvcUtilExtensions.NamingService,DLaB.CrmSvcUtilExtensions" /metadataproviderservice:"DLaB.CrmSvcUtilExtensions.Entity.MetadataProviderService,DLaB.CrmSvcUtilExtensions" /connectionstring:"AuthType=OAuth;Username=admin@CRM897785.onmicrosoft.com;Url=https://org25985de2.api.crm4.dynamics.com;AppId=51f81489-12ee-4a9e-aaae-a2591f45987d;RedirectUri=app://58145b91-0c36-4500-8554-080854f2ac97/;TokenCacheStorePath=C:\Users\mariu\AppData\Local\Temp\{069cb2b6-3d06-454e-a4f8-c56b6f866b96};LoginPrompt=Auto" 
//------------------------------------------------------------------------------

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]
[assembly: System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.71")]

namespace mwo.LiveRegistration.Plugins.Models
{
	
	/// <summary>
	/// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
	/// </summary>
	public partial class CrmServiceContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public CrmServiceContext(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistration"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistration> mwo_PluginStepRegistrationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistration>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.PluginType"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.PluginType> PluginTypeSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.PluginType>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.SdkMessage"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.SdkMessage> SdkMessageSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.SdkMessage>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.SdkMessageFilter"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.SdkMessageFilter> SdkMessageFilterSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.SdkMessageFilter>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep> SdkMessageProcessingStepSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage> SdkMessageProcessingStepImageSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.ServiceEndpoint"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.ServiceEndpoint> ServiceEndpointSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.ServiceEndpoint>();
			}
		}
	}
	
	internal sealed class EntityOptionSetEnum
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public static System.Nullable<int> GetEnum(Microsoft.Xrm.Sdk.Entity entity, string attributeLogicalName)
		{
			if (entity.Attributes.ContainsKey(attributeLogicalName))
			{
				Microsoft.Xrm.Sdk.OptionSetValue value = entity.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>(attributeLogicalName);
				if (value != null)
				{
					return value.Value;
				}
			}
			return null;
		}
	}
}