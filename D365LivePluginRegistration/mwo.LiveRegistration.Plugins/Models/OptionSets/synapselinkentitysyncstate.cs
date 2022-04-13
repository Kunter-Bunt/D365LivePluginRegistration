namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum synapselinkentitysyncstate
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		NotStarted = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InProgress = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Completed = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CompletedWithFailures = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		RequestedInitialData = 16,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Paused = 32,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		PostProcessing = 64,
	}
}
