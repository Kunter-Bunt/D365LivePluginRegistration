namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum cascadecaseclosurepreference
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Closeallchildcaseswhenparentcaseisclosed = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Dontallowparentcaseclosureuntilallchildcasesareclosed = 1,
	}
}
