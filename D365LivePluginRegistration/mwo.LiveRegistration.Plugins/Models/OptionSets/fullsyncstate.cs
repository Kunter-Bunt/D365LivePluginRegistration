namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum fullsyncstate
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		NotInitialized = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Initiating = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InProgress = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Completed = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Invalid = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AcceptMerge = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Failed = 6,
	}
}
