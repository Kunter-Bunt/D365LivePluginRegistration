namespace mwo.LiveRegistration.Plugins.Models
{

	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("mwo_pluginstepregistration")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public partial class mwo_PluginStepRegistration : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public mwo_PluginStepRegistration() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "mwo_pluginstepregistration";
		
		public const string EntityLogicalCollectionName = "mwo_pluginstepregistrations";
		
		public const string EntitySetName = "mwo_pluginstepregistrations";
		
		public const int EntityTypeCode = 10877;
		
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
		/// Unique identifier of the user who created the record.
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
		/// Date and time when the record was created.
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
		/// Unique identifier of the delegate user who created the record.
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
		/// Sequence number of the import that created this record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			set
			{
				this.OnPropertyChanging("ImportSequenceNumber");
				this.SetAttributeValue("importsequencenumber", value);
				this.OnPropertyChanged("ImportSequenceNumber");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who modified the record.
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
		/// Date and time when the record was modified.
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
		/// Unique identifier of the delegate user who modified the record.
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
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_asyncautodelete")]
		public System.Nullable<bool> mwo_AsyncAutoDelete
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("mwo_asyncautodelete");
			}
			set
			{
				this.OnPropertyChanging("mwo_AsyncAutoDelete");
				this.SetAttributeValue("mwo_asyncautodelete", value);
				this.OnPropertyChanged("mwo_AsyncAutoDelete");
			}
		}
		
		/// <summary>
		/// Whether to execute the step asynchronously.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_asynchronous")]
		public System.Nullable<bool> mwo_Asynchronous
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("mwo_asynchronous");
			}
			set
			{
				this.OnPropertyChanging("mwo_Asynchronous");
				this.SetAttributeValue("mwo_asynchronous", value);
				this.OnPropertyChanged("mwo_Asynchronous");
			}
		}
		
		/// <summary>
		/// The Description of the Plugin Step
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_description")]
		public string mwo_Description
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_description");
			}
			set
			{
				this.OnPropertyChanging("mwo_Description");
				this.SetAttributeValue("mwo_description", value);
				this.OnPropertyChanged("mwo_Description");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_eventhandler")]
		public string mwo_EventHandler
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_eventhandler");
			}
			set
			{
				this.OnPropertyChanging("mwo_EventHandler");
				this.SetAttributeValue("mwo_eventhandler", value);
				this.OnPropertyChanged("mwo_EventHandler");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_eventhandlertype")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.mwo_eventhandlertype> mwo_EventHandlerType
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mwo_eventhandlertype");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.mwo_eventhandlertype)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.mwo_eventhandlertype), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("mwo_EventHandlerType");
				if ((value == null))
				{
					this.SetAttributeValue("mwo_eventhandlertype", null);
				}
				else
				{
					this.SetAttributeValue("mwo_eventhandlertype", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("mwo_EventHandlerType");
			}
		}
		
		/// <summary>
		/// Filtering Attributes for the Update Message
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_filteringattributes")]
		public string mwo_FilteringAttributes
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_filteringattributes");
			}
			set
			{
				this.OnPropertyChanging("mwo_FilteringAttributes");
				this.SetAttributeValue("mwo_filteringattributes", value);
				this.OnPropertyChanged("mwo_FilteringAttributes");
			}
		}
		
		/// <summary>
		/// Images will be filtered to this comma separated list of entity attributes. Leave blank if you want all.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_imageattributes")]
		public string mwo_ImageAttributes
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_imageattributes");
			}
			set
			{
				this.OnPropertyChanging("mwo_ImageAttributes");
				this.SetAttributeValue("mwo_imageattributes", value);
				this.OnPropertyChanged("mwo_ImageAttributes");
			}
		}
		
		/// <summary>
		/// The Key of the Image in the Plugin Context
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_imagename")]
		public string mwo_ImageName
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_imagename");
			}
			set
			{
				this.OnPropertyChanging("mwo_ImageName");
				this.SetAttributeValue("mwo_imagename", value);
				this.OnPropertyChanged("mwo_ImageName");
			}
		}
		
		/// <summary>
		/// Select an Image Type you want to associate with the plugin step
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_imagetype")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.mwo_imagetype> mwo_ImageType
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mwo_imagetype");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.mwo_imagetype)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.mwo_imagetype), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("mwo_ImageType");
				if ((value == null))
				{
					this.SetAttributeValue("mwo_imagetype", null);
				}
				else
				{
					this.SetAttributeValue("mwo_imagetype", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("mwo_ImageType");
			}
		}
		
		/// <summary>
		/// Determines whether this record manages the according Dynamics Plugin Registration Step. Select no to untie the record and be able to delete it without deleting the actual  registration.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_managed")]
		public System.Nullable<bool> mwo_Managed
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("mwo_managed");
			}
			set
			{
				this.OnPropertyChanging("mwo_Managed");
				this.SetAttributeValue("mwo_managed", value);
				this.OnPropertyChanged("mwo_Managed");
			}
		}
		
		/// <summary>
		/// Required name field
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_name")]
		public string mwo_Name
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_name");
			}
			set
			{
				this.OnPropertyChanging("mwo_Name");
				this.SetAttributeValue("mwo_name", value);
				this.OnPropertyChanged("mwo_Name");
			}
		}
		
		/// <summary>
		/// Holds the Guid to the actual Dynamics Plugin Step
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_pluginstepid")]
		public string mwo_PluginStepId
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_pluginstepid");
			}
			set
			{
				this.OnPropertyChanging("mwo_PluginStepId");
				this.SetAttributeValue("mwo_pluginstepid", value);
				this.OnPropertyChanged("mwo_PluginStepId");
			}
		}
		
		/// <summary>
		/// Unique identifier for entity instances
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_pluginstepregistrationid")]
		public System.Nullable<System.Guid> mwo_PluginStepRegistrationId
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("mwo_pluginstepregistrationid");
			}
			set
			{
				this.OnPropertyChanging("mwo_PluginStepRegistrationId");
				this.SetAttributeValue("mwo_pluginstepregistrationid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("mwo_PluginStepRegistrationId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_pluginstepregistrationid")]
		public override System.Guid Id
		{
			get
			{
				return base.Id;
			}
			set
			{
				this.mwo_PluginStepRegistrationId = value;
			}
		}
		
		/// <summary>
		/// The Stage to execute in
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_pluginstepstage")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.mwo_pluginstage> mwo_PluginStepStage
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mwo_pluginstepstage");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.mwo_pluginstage)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.mwo_pluginstage), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("mwo_PluginStepStage");
				if ((value == null))
				{
					this.SetAttributeValue("mwo_pluginstepstage", null);
				}
				else
				{
					this.SetAttributeValue("mwo_pluginstepstage", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("mwo_PluginStepStage");
			}
		}
		
		/// <summary>
		/// The primary Entity you want to register to
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_primaryentity")]
		public string mwo_PrimaryEntity
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_primaryentity");
			}
			set
			{
				this.OnPropertyChanging("mwo_PrimaryEntity");
				this.SetAttributeValue("mwo_primaryentity", value);
				this.OnPropertyChanged("mwo_PrimaryEntity");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_rank")]
		public System.Nullable<int> mwo_Rank
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("mwo_rank");
			}
			set
			{
				this.OnPropertyChanging("mwo_Rank");
				this.SetAttributeValue("mwo_rank", value);
				this.OnPropertyChanged("mwo_Rank");
			}
		}
		
		/// <summary>
		/// The Dynamics SDK Message to Register to
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_sdkmessage")]
		public string mwo_SDKMessage
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_sdkmessage");
			}
			set
			{
				this.OnPropertyChanging("mwo_SDKMessage");
				this.SetAttributeValue("mwo_sdkmessage", value);
				this.OnPropertyChanged("mwo_SDKMessage");
			}
		}
		
		/// <summary>
		/// The secondary entity to register to, only valid in a few messages like Associate.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_secondaryentity")]
		public string mwo_SecondaryEntity
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_secondaryentity");
			}
			set
			{
				this.OnPropertyChanging("mwo_SecondaryEntity");
				this.SetAttributeValue("mwo_secondaryentity", value);
				this.OnPropertyChanged("mwo_SecondaryEntity");
			}
		}
		
		/// <summary>
		/// Unsecure Configuration for the Plugin Step
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mwo_stepconfiguration")]
		public string mwo_StepConfiguration
		{
			get
			{
				return this.GetAttributeValue<string>("mwo_stepconfiguration");
			}
			set
			{
				this.OnPropertyChanging("mwo_StepConfiguration");
				this.SetAttributeValue("mwo_stepconfiguration", value);
				this.OnPropertyChanged("mwo_StepConfiguration");
			}
		}
		
		/// <summary>
		/// Unique identifier for the organization
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
		/// Date and time that the record was migrated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			set
			{
				this.OnPropertyChanging("OverriddenCreatedOn");
				this.SetAttributeValue("overriddencreatedon", value);
				this.OnPropertyChanged("OverriddenCreatedOn");
			}
		}
		
		/// <summary>
		/// Status of the Plugin Step Registration
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistrationState> statecode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistrationState)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.mwo_PluginStepRegistrationState), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("statecode");
				if ((value == null))
				{
					this.SetAttributeValue("statecode", null);
				}
				else
				{
					this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("statecode");
			}
		}
		
		/// <summary>
		/// Reason for the status of the Plugin Step Registration
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public System.Nullable<mwo.LiveRegistration.Plugins.Models.mwo_pluginstepregistration_statuscode> statuscode
		{
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
				if ((optionSet != null))
				{
					return ((mwo.LiveRegistration.Plugins.Models.mwo_pluginstepregistration_statuscode)(System.Enum.ToObject(typeof(mwo.LiveRegistration.Plugins.Models.mwo_pluginstepregistration_statuscode), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			set
			{
				this.OnPropertyChanging("statuscode");
				if ((value == null))
				{
					this.SetAttributeValue("statuscode", null);
				}
				else
				{
					this.SetAttributeValue("statuscode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("statuscode");
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
		public System.Nullable<int> TimeZoneRuleVersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
			}
			set
			{
				this.OnPropertyChanging("TimeZoneRuleVersionNumber");
				this.SetAttributeValue("timezoneruleversionnumber", value);
				this.OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}
		
		/// <summary>
		/// Time zone code that was in use when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
		public System.Nullable<int> UTCConversionTimeZoneCode
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
			}
			set
			{
				this.OnPropertyChanging("UTCConversionTimeZoneCode");
				this.SetAttributeValue("utcconversiontimezonecode", value);
				this.OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}
		
		/// <summary>
		/// Version Number
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
	}
}
