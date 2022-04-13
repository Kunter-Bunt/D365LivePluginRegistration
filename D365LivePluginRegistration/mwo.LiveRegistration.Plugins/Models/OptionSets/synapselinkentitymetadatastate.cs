namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum synapselinkentitymetadatastate
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		NotCreated = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MetadataCreating = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		RelationshipCreating = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Created = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Failure = 16,
	}
}
