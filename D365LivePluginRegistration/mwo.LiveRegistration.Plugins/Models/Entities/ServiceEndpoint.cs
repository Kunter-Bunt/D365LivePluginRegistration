namespace mwo.LiveRegistration.Plugins.Models
{

	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("serviceendpoint")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public partial class ServiceEndpoint : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public ServiceEndpoint() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "serviceendpoint";
		
		public const string EntityLogicalCollectionName = "serviceendpoints";
		
		public const string EntitySetName = "serviceendpoints";
		
		public const int EntityTypeCode = 4618;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>
		/// Specifies mode of authentication with SB
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("authtype")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_authtype> AuthType
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("authtype");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_authtype)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_authtype), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("AuthType");
				if ((value == null))
				{
					this.SetAttributeValue("authtype", null);
				}
				else
				{
					this.SetAttributeValue("authtype", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("AuthType");
			}
		}
		
		/// <summary>
		/// Authentication Value
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("authvalue")]
		public string AuthValue
		{
			get
			{
				return this.GetAttributeValue<string>("authvalue");
			}
			set
			{
				this.OnPropertyChanging("AuthValue");
				this.SetAttributeValue("authvalue", value);
				this.OnPropertyChanged("AuthValue");
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.componentstate> ComponentState
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componentstate");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.componentstate)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.componentstate), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
		}
		
		/// <summary>
		/// Connection mode to contact the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("connectionmode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_connectionmode> ConnectionMode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("connectionmode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_connectionmode)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_connectionmode), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("ConnectionMode");
				if ((value == null))
				{
					this.SetAttributeValue("connectionmode", null);
				}
				else
				{
					this.SetAttributeValue("connectionmode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("ConnectionMode");
			}
		}
		
		/// <summary>
		/// Type of the endpoint contract.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("contract")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_contract> Contract
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("contract");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_contract)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_contract), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("Contract");
				if ((value == null))
				{
					this.SetAttributeValue("contract", null);
				}
				else
				{
					this.SetAttributeValue("contract", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("Contract");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		/// <summary>
		/// Date and time when the service endpoint was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
		}
		
		/// <summary>
		/// Description of the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
		public string Description
		{
			get
			{
				return this.GetAttributeValue<string>("description");
			}
			set
			{
				this.OnPropertyChanging("Description");
				this.SetAttributeValue("description", value);
				this.OnPropertyChanged("Description");
			}
		}
		
		/// <summary>
		/// Version in which the form is introduced.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("introducedversion")]
		public string IntroducedVersion
		{
			get
			{
				return this.GetAttributeValue<string>("introducedversion");
			}
			set
			{
				this.OnPropertyChanging("IntroducedVersion");
				this.SetAttributeValue("introducedversion", value);
				this.OnPropertyChanged("IntroducedVersion");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isauthvalueset")]
		public System.Nullable<bool> IsAuthValueSet
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("isauthvalueset");
			}
		}
		
		/// <summary>
		/// Information that specifies whether this component can be customized.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomizable")]
		public Microsoft.Xrm.Sdk.BooleanManagedProperty IsCustomizable
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("iscustomizable");
			}
			set
			{
				this.OnPropertyChanging("IsCustomizable");
				this.SetAttributeValue("iscustomizable", value);
				this.OnPropertyChanged("IsCustomizable");
			}
		}
		
		/// <summary>
		/// Information that specifies whether this component is managed.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
		public System.Nullable<bool> IsManaged
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("issaskeyset")]
		public System.Nullable<bool> IsSASKeySet
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("issaskeyset");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("issastokenset")]
		public System.Nullable<bool> IsSASTokenSet
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("issastokenset");
			}
		}
		
		/// <summary>
		/// Unique identifier for keyvaultreference associated with serviceendpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("keyvaultreferenceid")]
		public Microsoft.Xrm.Sdk.EntityReference KeyVaultReferenceId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("keyvaultreferenceid");
			}
			set
			{
				this.OnPropertyChanging("KeyVaultReferenceId");
				this.SetAttributeValue("keyvaultreferenceid", value);
				this.OnPropertyChanged("KeyVaultReferenceId");
			}
		}
		
		/// <summary>
		/// Specifies the character encoding for message content
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("messagecharset")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_messagecharset> MessageCharset
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("messagecharset");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_messagecharset)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_messagecharset), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("MessageCharset");
				if ((value == null))
				{
					this.SetAttributeValue("messagecharset", null);
				}
				else
				{
					this.SetAttributeValue("messagecharset", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("MessageCharset");
			}
		}
		
		/// <summary>
		/// Content type of the message
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("messageformat")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_messageformat> MessageFormat
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("messageformat");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_messageformat)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_messageformat), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("MessageFormat");
				if ((value == null))
				{
					this.SetAttributeValue("messageformat", null);
				}
				else
				{
					this.SetAttributeValue("messageformat", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("MessageFormat");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		/// <summary>
		/// Date and time when the service endpoint was last modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// Name of Service end point.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
		public string Name
		{
			get
			{
				return this.GetAttributeValue<string>("name");
			}
			set
			{
				this.OnPropertyChanging("Name");
				this.SetAttributeValue("name", value);
				this.OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// Full service endpoint address.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("namespaceaddress")]
		public string NamespaceAddress
		{
			get
			{
				return this.GetAttributeValue<string>("namespaceaddress");
			}
			set
			{
				this.OnPropertyChanging("NamespaceAddress");
				this.SetAttributeValue("namespaceaddress", value);
				this.OnPropertyChanged("NamespaceAddress");
			}
		}
		
		/// <summary>
		/// Format of Service Bus Namespace
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("namespaceformat")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_namespaceformat> NamespaceFormat
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("namespaceformat");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_namespaceformat)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_namespaceformat), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("NamespaceFormat");
				if ((value == null))
				{
					this.SetAttributeValue("namespaceformat", null);
				}
				else
				{
					this.SetAttributeValue("namespaceformat", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("NamespaceFormat");
			}
		}
		
		/// <summary>
		/// Unique identifier of the organization with which the service endpoint is associated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		public Microsoft.Xrm.Sdk.EntityReference OrganizationId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overwritetime")]
		public System.Nullable<System.DateTime> OverwriteTime
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overwritetime");
			}
		}
		
		/// <summary>
		/// Path to the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("path")]
		public string Path
		{
			get
			{
				return this.GetAttributeValue<string>("path");
			}
			set
			{
				this.OnPropertyChanging("Path");
				this.SetAttributeValue("path", value);
				this.OnPropertyChanged("Path");
			}
		}
		
		/// <summary>
		/// For internal use only. Holds miscellaneous properties related to runtime integration.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("runtimeintegrationproperties")]
		public string RuntimeIntegrationProperties
		{
			get
			{
				return this.GetAttributeValue<string>("runtimeintegrationproperties");
			}
			set
			{
				this.OnPropertyChanging("RuntimeIntegrationProperties");
				this.SetAttributeValue("runtimeintegrationproperties", value);
				this.OnPropertyChanged("RuntimeIntegrationProperties");
			}
		}
		
		/// <summary>
		/// Shared Access Key
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("saskey")]
		public string SASKey
		{
			get
			{
				return this.GetAttributeValue<string>("saskey");
			}
			set
			{
				this.OnPropertyChanging("SASKey");
				this.SetAttributeValue("saskey", value);
				this.OnPropertyChanged("SASKey");
			}
		}
		
		/// <summary>
		/// Shared Access Key Name
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("saskeyname")]
		public string SASKeyName
		{
			get
			{
				return this.GetAttributeValue<string>("saskeyname");
			}
			set
			{
				this.OnPropertyChanging("SASKeyName");
				this.SetAttributeValue("saskeyname", value);
				this.OnPropertyChanged("SASKeyName");
			}
		}
		
		/// <summary>
		/// Shared Access Token
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sastoken")]
		public string SASToken
		{
			get
			{
				return this.GetAttributeValue<string>("sastoken");
			}
			set
			{
				this.OnPropertyChanging("SASToken");
				this.SetAttributeValue("sastoken", value);
				this.OnPropertyChanged("SASToken");
			}
		}
		
		/// <summary>
		/// Specifies schema type for event grid events
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("schematype")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_schematype> SchemaType
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("schematype");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_schematype)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_schematype), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("SchemaType");
				if ((value == null))
				{
					this.SetAttributeValue("schematype", null);
				}
				else
				{
					this.SetAttributeValue("schematype", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("SchemaType");
			}
		}
		
		/// <summary>
		/// Unique identifier of the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("serviceendpointid")]
		public System.Nullable<System.Guid> ServiceEndpointId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("serviceendpointid");
			}
			set
			{
				this.OnPropertyChanging("ServiceEndpointId");
				this.SetAttributeValue("serviceendpointid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("ServiceEndpointId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("serviceendpointid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.ServiceEndpointId = value;
			}
		}
		
		/// <summary>
		/// Unique identifier of the service endpoint.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("serviceendpointidunique")]
		public System.Nullable<System.Guid> ServiceEndpointIdUnique
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("serviceendpointidunique");
			}
		}
		
		/// <summary>
		/// Unique identifier of the associated solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
		public System.Nullable<System.Guid> SolutionId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
			}
		}
		
		/// <summary>
		/// Namespace of the App Fabric solution.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionnamespace")]
		public string SolutionNamespace
		{
			get
			{
				return this.GetAttributeValue<string>("solutionnamespace");
			}
			set
			{
				this.OnPropertyChanging("SolutionNamespace");
				this.SetAttributeValue("solutionnamespace", value);
				this.OnPropertyChanged("SolutionNamespace");
			}
		}
		
		/// <summary>
		/// Full service endpoint Url.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("url")]
		public string Url
		{
			get
			{
				return this.GetAttributeValue<string>("url");
			}
			set
			{
				this.OnPropertyChanging("Url");
				this.SetAttributeValue("url", value);
				this.OnPropertyChanged("Url");
			}
		}
		
		/// <summary>
		/// Use Auth Information in KeyVault
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("usekeyvaultconfiguration")]
		public System.Nullable<bool> UseKeyVaultConfiguration
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("usekeyvaultconfiguration");
			}
			set
			{
				this.OnPropertyChanging("UseKeyVaultConfiguration");
				this.SetAttributeValue("usekeyvaultconfiguration", value);
				this.OnPropertyChanged("UseKeyVaultConfiguration");
			}
		}
		
		/// <summary>
		/// Additional user claim value type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("userclaim")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.serviceendpoint_userclaim> UserClaim
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("userclaim");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.serviceendpoint_userclaim)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.serviceendpoint_userclaim), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("UserClaim");
				if ((value == null))
				{
					this.SetAttributeValue("userclaim", null);
				}
				else
				{
					this.SetAttributeValue("userclaim", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("UserClaim");
			}
		}
		
		/// <summary>
		/// 1:N serviceendpoint_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("serviceendpoint_sdkmessageprocessingstep")]
		public System.Collections.Generic.IEnumerable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep> serviceendpoint_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("serviceendpoint_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("serviceendpoint_sdkmessageprocessingstep");
				this.SetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("serviceendpoint_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("serviceendpoint_sdkmessageprocessingstep");
			}
		}
	}
}
