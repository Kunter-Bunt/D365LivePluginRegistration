namespace mwo.LiveRegistration.Plugins.Models
{

	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessageprocessingstep")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public partial class SdkMessageProcessingStep : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public SdkMessageProcessingStep() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "sdkmessageprocessingstep";
		
		public const string EntityLogicalCollectionName = "sdkmessageprocessingsteps";
		
		public const string EntitySetName = "sdkmessageprocessingsteps";
		
		public const int EntityTypeCode = 4608;
		
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
		/// Indicates whether the asynchronous system job is automatically deleted on completion.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("asyncautodelete")]
		public System.Nullable<bool> AsyncAutoDelete
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("asyncautodelete");
			}
			set
			{
				this.OnPropertyChanging("AsyncAutoDelete");
				this.SetAttributeValue("asyncautodelete", value);
				this.OnPropertyChanged("AsyncAutoDelete");
			}
		}
		
		/// <summary>
		/// Identifies whether a SDK Message Processing Step type will be ReadOnly or Read Write. false - ReadWrite, true - ReadOnly 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("canusereadonlyconnection")]
		public System.Nullable<bool> CanUseReadOnlyConnection
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("canusereadonlyconnection");
			}
			set
			{
				this.OnPropertyChanging("CanUseReadOnlyConnection");
				this.SetAttributeValue("canusereadonlyconnection", value);
				this.OnPropertyChanged("CanUseReadOnlyConnection");
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("category")]
		public string Category
		{
			get
			{
				return this.GetAttributeValue<string>("category");
			}
			set
			{
				this.OnPropertyChanging("Category");
				this.SetAttributeValue("category", value);
				this.OnPropertyChanged("Category");
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
		/// Step-specific configuration for the plug-in type. Passed to the plug-in constructor at run time.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("configuration")]
		public string Configuration
		{
			get
			{
				return this.GetAttributeValue<string>("configuration");
			}
			set
			{
				this.OnPropertyChanging("Configuration");
				this.SetAttributeValue("configuration", value);
				this.OnPropertyChanged("Configuration");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the SDK message processing step.
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
		/// Date and time when the SDK message processing step was created.
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
		/// Unique identifier of the delegate user who created the sdkmessageprocessingstep.
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
		/// Customization level of the SDK message processing step.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
		public System.Nullable<int> CustomizationLevel
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
			}
		}
		
		/// <summary>
		/// Description of the SDK message processing step.
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
		/// Configuration for sending pipeline events to the Event Expander service.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("eventexpander")]
		public string EventExpander
		{
			get
			{
				return this.GetAttributeValue<string>("eventexpander");
			}
			set
			{
				this.OnPropertyChanging("EventExpander");
				this.SetAttributeValue("eventexpander", value);
				this.OnPropertyChanged("EventExpander");
			}
		}
		
		/// <summary>
		/// Unique identifier of the associated event handler.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("eventhandler")]
		public Microsoft.Xrm.Sdk.EntityReference EventHandler
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("eventhandler");
			}
			set
			{
				this.OnPropertyChanging("EventHandler");
				this.SetAttributeValue("eventhandler", value);
				this.OnPropertyChanged("EventHandler");
			}
		}
		
		/// <summary>
		/// Comma-separated list of attributes. If at least one of these attributes is modified, the plug-in should execute.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("filteringattributes")]
		public string FilteringAttributes
		{
			get
			{
				return this.GetAttributeValue<string>("filteringattributes");
			}
			set
			{
				this.OnPropertyChanging("FilteringAttributes");
				this.SetAttributeValue("filteringattributes", value);
				this.OnPropertyChanged("FilteringAttributes");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user to impersonate context when step is executed.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("impersonatinguserid")]
		public Microsoft.Xrm.Sdk.EntityReference ImpersonatingUserId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("impersonatinguserid");
			}
			set
			{
				this.OnPropertyChanging("ImpersonatingUserId");
				this.SetAttributeValue("impersonatinguserid", value);
				this.OnPropertyChanged("ImpersonatingUserId");
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
		/// Identifies if a plug-in should be executed from a parent pipeline, a child pipeline, or both.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("invocationsource")]
		[System.ObsoleteAttribute()]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_invocationsource> InvocationSource
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("invocationsource");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_invocationsource)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_invocationsource), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("InvocationSource");
				if ((value == null))
				{
					this.SetAttributeValue("invocationsource", null);
				}
				else
				{
					this.SetAttributeValue("invocationsource", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("InvocationSource");
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
		/// Information that specifies whether this component should be hidden.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ishidden")]
		public Microsoft.Xrm.Sdk.BooleanManagedProperty IsHidden
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("ishidden");
			}
			set
			{
				this.OnPropertyChanging("IsHidden");
				this.SetAttributeValue("ishidden", value);
				this.OnPropertyChanged("IsHidden");
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
		/// Run-time mode of execution, for example, synchronous or asynchronous.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_mode> Mode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_mode)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_mode), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("Mode");
				if ((value == null))
				{
					this.SetAttributeValue("mode", null);
				}
				else
				{
					this.SetAttributeValue("mode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("Mode");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the SDK message processing step.
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
		/// Date and time when the SDK message processing step was last modified.
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
		/// Unique identifier of the delegate user who last modified the sdkmessageprocessingstep.
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
		/// Name of SdkMessage processing step.
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
		/// Unique identifier of the organization with which the SDK message processing step is associated.
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
		/// Unique identifier of the plug-in type associated with the step.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
		[System.ObsoleteAttribute()]
		public Microsoft.Xrm.Sdk.EntityReference PluginTypeId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("plugintypeid");
			}
			set
			{
				this.OnPropertyChanging("PluginTypeId");
				this.SetAttributeValue("plugintypeid", value);
				this.OnPropertyChanged("PluginTypeId");
			}
		}
		
		/// <summary>
		/// Processing order within the stage.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rank")]
		public System.Nullable<int> Rank
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("rank");
			}
			set
			{
				this.OnPropertyChanging("Rank");
				this.SetAttributeValue("rank", value);
				this.OnPropertyChanged("Rank");
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
		/// Unique identifier of the SDK message filter.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilterid")]
		public Microsoft.Xrm.Sdk.EntityReference SdkMessageFilterId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessagefilterid");
			}
			set
			{
				this.OnPropertyChanging("SdkMessageFilterId");
				this.SetAttributeValue("sdkmessagefilterid", value);
				this.OnPropertyChanged("SdkMessageFilterId");
			}
		}
		
		/// <summary>
		/// Unique identifier of the SDK message.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
		public Microsoft.Xrm.Sdk.EntityReference SdkMessageId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageid");
			}
			set
			{
				this.OnPropertyChanging("SdkMessageId");
				this.SetAttributeValue("sdkmessageid", value);
				this.OnPropertyChanged("SdkMessageId");
			}
		}
		
		/// <summary>
		/// Unique identifier of the SDK message processing step entity.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepid")]
		public System.Nullable<System.Guid> SdkMessageProcessingStepId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageprocessingstepid");
			}
			set
			{
				this.OnPropertyChanging("SdkMessageProcessingStepId");
				this.SetAttributeValue("sdkmessageprocessingstepid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("SdkMessageProcessingStepId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.SdkMessageProcessingStepId = value;
			}
		}
		
		/// <summary>
		/// Unique identifier of the SDK message processing step.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepidunique")]
		public System.Nullable<System.Guid> SdkMessageProcessingStepIdUnique
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageprocessingstepidunique");
			}
		}
		
		/// <summary>
		/// Unique identifier of the Sdk message processing step secure configuration.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepsecureconfigid")]
		public Microsoft.Xrm.Sdk.EntityReference SdkMessageProcessingStepSecureConfigId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageprocessingstepsecureconfigid");
			}
			set
			{
				this.OnPropertyChanging("SdkMessageProcessingStepSecureConfigId");
				this.SetAttributeValue("sdkmessageprocessingstepsecureconfigid", value);
				this.OnPropertyChanged("SdkMessageProcessingStepSecureConfigId");
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
		/// Stage in the execution pipeline that the SDK message processing step is in.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stage")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_stage> Stage
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("stage");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_stage)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_stage), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("Stage");
				if ((value == null))
				{
					this.SetAttributeValue("stage", null);
				}
				else
				{
					this.SetAttributeValue("stage", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("Stage");
			}
		}
		
		/// <summary>
		/// Status of the SDK message processing step.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepState> StateCode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepState)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepState), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("StateCode");
				if ((value == null))
				{
					this.SetAttributeValue("statecode", null);
				}
				else
				{
					this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("StateCode");
			}
		}
		
		/// <summary>
		/// Reason for the status of the SDK message processing step.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_statuscode> StatusCode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_statuscode)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_statuscode), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("StatusCode");
				if ((value == null))
				{
					this.SetAttributeValue("statuscode", null);
				}
				else
				{
					this.SetAttributeValue("statuscode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("StatusCode");
			}
		}
		
		/// <summary>
		/// Deployment that the SDK message processing step should be executed on; server, client, or both.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("supporteddeployment")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_supporteddeployment> SupportedDeployment
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("supporteddeployment");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_supporteddeployment)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.sdkmessageprocessingstep_supporteddeployment), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("SupportedDeployment");
				if ((value == null))
				{
					this.SetAttributeValue("supporteddeployment", null);
				}
				else
				{
					this.SetAttributeValue("supporteddeployment", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("SupportedDeployment");
			}
		}
		
		/// <summary>
		/// Number that identifies a specific revision of the SDK message processing step. 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N sdkmessageprocessingstepid_sdkmessageprocessingstepimage
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("sdkmessageprocessingstepid_sdkmessageprocessingstepimage")]
		public System.Collections.Generic.IEnumerable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage> sdkmessageprocessingstepid_sdkmessageprocessingstepimage
		{
			get
			{
				return this.GetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage>("sdkmessageprocessingstepid_sdkmessageprocessingstepimage", null);
			}
			set
			{
				this.OnPropertyChanging("sdkmessageprocessingstepid_sdkmessageprocessingstepimage");
				this.SetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStepImage>("sdkmessageprocessingstepid_sdkmessageprocessingstepimage", null, value);
				this.OnPropertyChanged("sdkmessageprocessingstepid_sdkmessageprocessingstepimage");
			}
		}
		
		/// <summary>
		/// N:1 plugintype_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("eventhandler")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("plugintype_sdkmessageprocessingstep")]
		public mwo.LiveRegistration.Plugins.Models.PluginType plugintype_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntity<mwo.LiveRegistration.Plugins.Models.PluginType>("plugintype_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("plugintype_sdkmessageprocessingstep");
				this.SetRelatedEntity<mwo.LiveRegistration.Plugins.Models.PluginType>("plugintype_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("plugintype_sdkmessageprocessingstep");
			}
		}
		
		/// <summary>
		/// N:1 plugintypeid_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("plugintypeid_sdkmessageprocessingstep")]
		public mwo.LiveRegistration.Plugins.Models.PluginType plugintypeid_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntity<mwo.LiveRegistration.Plugins.Models.PluginType>("plugintypeid_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("plugintypeid_sdkmessageprocessingstep");
				this.SetRelatedEntity<mwo.LiveRegistration.Plugins.Models.PluginType>("plugintypeid_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("plugintypeid_sdkmessageprocessingstep");
			}
		}
		
		/// <summary>
		/// N:1 sdkmessagefilterid_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilterid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("sdkmessagefilterid_sdkmessageprocessingstep")]
		public mwo.LiveRegistration.Plugins.Models.SdkMessageFilter sdkmessagefilterid_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntity<mwo.LiveRegistration.Plugins.Models.SdkMessageFilter>("sdkmessagefilterid_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("sdkmessagefilterid_sdkmessageprocessingstep");
				this.SetRelatedEntity<mwo.LiveRegistration.Plugins.Models.SdkMessageFilter>("sdkmessagefilterid_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("sdkmessagefilterid_sdkmessageprocessingstep");
			}
		}
		
		/// <summary>
		/// N:1 sdkmessageid_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("sdkmessageid_sdkmessageprocessingstep")]
		public mwo.LiveRegistration.Plugins.Models.SdkMessage sdkmessageid_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntity<mwo.LiveRegistration.Plugins.Models.SdkMessage>("sdkmessageid_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("sdkmessageid_sdkmessageprocessingstep");
				this.SetRelatedEntity<mwo.LiveRegistration.Plugins.Models.SdkMessage>("sdkmessageid_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("sdkmessageid_sdkmessageprocessingstep");
			}
		}
		
		/// <summary>
		/// N:1 serviceendpoint_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("eventhandler")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("serviceendpoint_sdkmessageprocessingstep")]
		public mwo.LiveRegistration.Plugins.Models.ServiceEndpoint serviceendpoint_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntity<mwo.LiveRegistration.Plugins.Models.ServiceEndpoint>("serviceendpoint_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("serviceendpoint_sdkmessageprocessingstep");
				this.SetRelatedEntity<mwo.LiveRegistration.Plugins.Models.ServiceEndpoint>("serviceendpoint_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("serviceendpoint_sdkmessageprocessingstep");
			}
		}
	}
}
