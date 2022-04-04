namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum serviceendpoint_authtype
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		ACS = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		SASKey = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		SASToken = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		WebhookKey = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		HttpHeader = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		HttpQueryString = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		ConnectionString = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AccessKey = 8,
	}
}
