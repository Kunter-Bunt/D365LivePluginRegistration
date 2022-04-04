namespace mwo.LiveRegistration.Plugins.Models
{

	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.1.0.82")]
	public enum msdyn_ocsystemmessageeventtype
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentjoinedconversation = 192350000,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultaccepted = 192350001,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoagentaccepted = 192350002,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultstarted = 192350003,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultrequestfailed = 192350004,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoagentrequested = 192350005,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoagentfailed = 192350006,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultrejected = 192350007,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoagentrejected = 192350008,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultrequesttimedout = 192350009,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoagenttimedout = 192350010,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoqueuestarted = 192350011,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertoqueuefailed = 192350012,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentdisconnectedfromconversation = 192350013,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentendedconversation = 192350014,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Sessionended = 192350015,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Consultsessionended = 192350016,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentassignedtoconversation = 192350017,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentcouldntbeassignedtoconversation = 192350018,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customerendedconversation = 192350019,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customerdisconnected = 192350020,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customerspositioninqueue = 192350021,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentsmessagecouldntbesent = 192350022,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CustomersmessagecouldntbesentOutsideofoperationhours = 192350023,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customerisnextinline = 192350024,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MessagecouldntbedeliveredUnsupportedmessagetype = 192350025,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Voicecallrequested = 192350026,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Voicecallaccepted = 192350027,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Voicecalldeclined = 192350028,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MessagecouldntbesentOutsideallowedtimeframe = 192350029,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AveragewaittimeforcustomersMinutes = 192350030,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AveragewaittimeforcustomersHours = 192350031,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		AveragewaittimeforcustomersHoursandminutes = 192350032,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Voicecallended = 192350033,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MessagecouldntbesentAchannelaccountcantmessageanotheraccountwithinOmnichannel = 192350034,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Holidaymessagetocustomer = 192350035,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Outofoperatinghourmessagetocustomer = 192350036,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CouldntfindthechannelaccountinOmnichannel = 192350037,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customersfilecouldntbeattachedbecauseitstoobig = 192350038,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transfertooutofoperatinghourqueue = 192350039,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MessagecouldntbesentFilecouldntbeattached = 192350040,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		LeaveasmanymessagesasyoudlikeandwellgetbacktoyouassoonaspossibleWellsaveyourchathistorysoyoucanleaveandcomebackanytime = 192350041,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customerputonhold = 192350042,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Customernolongeronhold = 192350043,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MessageorattachmentfailedtosendProvidingerrordetailsincludingerrorcodereasonforfailuremessageidtimestampandtransactionid = 192350044,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transcriptionstarted = 192350045,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transcriptionpaused = 192350046,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transcriptionresumed = 192350047,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Transcriptionstopped = 192350048,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Recordingandtranscriptionstarted = 192350049,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Recordingandtranscriptionpaused = 192350050,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Recordingandtranscriptionresumed = 192350051,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Recordingandtranscriptionstopped = 192350052,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Trialusagelimitexceeded = 192350053,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Trialconversationtimelimitexceeded = 192350054,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Endconversationduetooverflow = 192350055,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		GreetingMessageforAsyncChannels = 192350056,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CustomerhasoptedoutfromAsyncConversation = 192350057,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentleftconsultconversation = 192350058,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentleftcustomerconversation = 192350059,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentacceptedconsultconversation = 192350060,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentjoinedcustomerconversation = 192350061,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentendedconsultconversation = 192350062,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Agentremovedfromconsultconversation = 192350063,
	}
}
