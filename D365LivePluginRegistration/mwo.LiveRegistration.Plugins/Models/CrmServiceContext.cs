namespace mwo.LiveRegistration.Plugins.Models
{

	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public partial class CrmServiceContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public CrmServiceContext(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistration"/> entities.
		/// </summary>
		public System.Linq.IQueryable<mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistration> mwo_PluginStepRegistrationSet
		{
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
			get
			{
				return this.CreateQuery<mwo.LiveRegistration.Plugins.Models.ServiceEndpoint>();
			}
		}
	}
}
