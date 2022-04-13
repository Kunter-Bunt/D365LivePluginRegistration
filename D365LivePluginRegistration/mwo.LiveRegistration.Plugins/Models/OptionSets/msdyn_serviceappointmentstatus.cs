namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum msdyn_serviceappointmentstatus
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Pending = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Reserved = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InProgress = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Arrived = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Completed = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Canceled = 9,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		NoShow = 10,
	}
}
