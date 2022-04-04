namespace mwo.LiveRegistration.Plugins.Models
{

	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("plugintype")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public partial class PluginType : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public PluginType() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "plugintype";
		
		public const string EntityLogicalCollectionName = "plugintypes";
		
		public const string EntitySetName = "plugintypes";
		
		public const int EntityTypeCode = 4602;
		
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
		/// Full path name of the plug-in assembly.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("assemblyname")]
		public string AssemblyName
		{
			get
			{
				return this.GetAttributeValue<string>("assemblyname");
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
		/// Unique identifier of the user who created the plug-in type.
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
		/// Date and time when the plug-in type was created.
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
		/// Unique identifier of the delegate user who created the plugintype.
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
		/// Culture code for the plug-in assembly.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("culture")]
		public string Culture
		{
			get
			{
				return this.GetAttributeValue<string>("culture");
			}
		}
		
		/// <summary>
		/// Customization level of the plug-in type.
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
		/// Serialized Custom Activity Type information, including required arguments. For more information, see SandboxCustomActivityInfo.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customworkflowactivityinfo")]
		public string CustomWorkflowActivityInfo
		{
			get
			{
				return this.GetAttributeValue<string>("customworkflowactivityinfo");
			}
		}
		
		/// <summary>
		/// Description of the plug-in type.
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
		/// User friendly name for the plug-in.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("friendlyname")]
		public string FriendlyName
		{
			get
			{
				return this.GetAttributeValue<string>("friendlyname");
			}
			set
			{
				this.OnPropertyChanging("FriendlyName");
				this.SetAttributeValue("friendlyname", value);
				this.OnPropertyChanged("FriendlyName");
			}
		}
		
		/// <summary>
		/// 
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
		/// Indicates if the plug-in is a custom activity for workflows.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isworkflowactivity")]
		public System.Nullable<bool> IsWorkflowActivity
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("isworkflowactivity");
			}
		}
		
		/// <summary>
		/// Major of the version number of the assembly for the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("major")]
		public System.Nullable<int> Major
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("major");
			}
		}
		
		/// <summary>
		/// Minor of the version number of the assembly for the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("minor")]
		public System.Nullable<int> Minor
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("minor");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who last modified the plug-in type.
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
		/// Date and time when the plug-in type was last modified.
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
		/// Unique identifier of the delegate user who last modified the plugintype.
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
		/// Name of the plug-in type.
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
		/// Unique identifier of the organization with which the plug-in type is associated.
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
		/// Unique identifier of the plug-in assembly that contains this plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pluginassemblyid")]
		public Microsoft.Xrm.Sdk.EntityReference PluginAssemblyId
		{
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("pluginassemblyid");
			}
			set
			{
				this.OnPropertyChanging("PluginAssemblyId");
				this.SetAttributeValue("pluginassemblyid", value);
				this.OnPropertyChanged("PluginAssemblyId");
			}
		}
		
		/// <summary>
		/// Unique identifier of the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
		public System.Nullable<System.Guid> PluginTypeId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("plugintypeid");
			}
			set
			{
				this.OnPropertyChanging("PluginTypeId");
				this.SetAttributeValue("plugintypeid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("PluginTypeId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.PluginTypeId = value;
			}
		}
		
		/// <summary>
		/// Unique identifier of the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeidunique")]
		public System.Nullable<System.Guid> PluginTypeIdUnique
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("plugintypeidunique");
			}
		}
		
		/// <summary>
		/// Public key token of the assembly for the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publickeytoken")]
		public string PublicKeyToken
		{
			get
			{
				return this.GetAttributeValue<string>("publickeytoken");
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
		/// Fully qualified type name of the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("typename")]
		public string TypeName
		{
			get
			{
				return this.GetAttributeValue<string>("typename");
			}
			set
			{
				this.OnPropertyChanging("TypeName");
				this.SetAttributeValue("typename", value);
				this.OnPropertyChanged("TypeName");
			}
		}
		
		/// <summary>
		/// Version number of the assembly for the plug-in type.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("version")]
		public string Version
		{
			get
			{
				return this.GetAttributeValue<string>("version");
			}
		}
		
		/// <summary>
		/// 
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
		/// Group name of workflow custom activity.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("workflowactivitygroupname")]
		public string WorkflowActivityGroupName
		{
			get
			{
				return this.GetAttributeValue<string>("workflowactivitygroupname");
			}
			set
			{
				this.OnPropertyChanging("WorkflowActivityGroupName");
				this.SetAttributeValue("workflowactivitygroupname", value);
				this.OnPropertyChanged("WorkflowActivityGroupName");
			}
		}
		
		/// <summary>
		/// 1:N plugintype_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("plugintype_sdkmessageprocessingstep")]
		public System.Collections.Generic.IEnumerable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep> plugintype_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("plugintype_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("plugintype_sdkmessageprocessingstep");
				this.SetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("plugintype_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("plugintype_sdkmessageprocessingstep");
			}
		}
		
		/// <summary>
		/// 1:N plugintypeid_sdkmessageprocessingstep
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("plugintypeid_sdkmessageprocessingstep")]
		public System.Collections.Generic.IEnumerable<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep> plugintypeid_sdkmessageprocessingstep
		{
			get
			{
				return this.GetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("plugintypeid_sdkmessageprocessingstep", null);
			}
			set
			{
				this.OnPropertyChanging("plugintypeid_sdkmessageprocessingstep");
				this.SetRelatedEntities<mwo.LiveRegistration.Plugins.Models.SdkMessageProcessingStep>("plugintypeid_sdkmessageprocessingstep", null, value);
				this.OnPropertyChanged("plugintypeid_sdkmessageprocessingstep");
			}
		}
	}
}
