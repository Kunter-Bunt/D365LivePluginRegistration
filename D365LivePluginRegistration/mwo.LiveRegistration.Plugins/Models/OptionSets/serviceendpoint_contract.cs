namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum serviceendpoint_contract
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		OneWay = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Queue = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Rest = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		TwoWay = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Topic = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Queue_Persistent = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		EventHub = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Webhook = 8,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		EventGrid = 9,
	}
}
