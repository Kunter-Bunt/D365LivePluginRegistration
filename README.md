# D365LivePluginRegistration
This project holds a Solution with an Entity that can be used to manage Plugin **Step** Registrations at runtime in the target environment.
When creating a record of the enclosed Entity (_mwo_pluginstepregistration_) this will create a step for the specified step, optionally also including an image.
This was designed to make it easier to implement configurable plugins that will be dynamically registered by introducing an abstraction layer that can be easily managed. 

# Usage Sample
Lets assume you need to develop a solution with a functionality for which you dont know what entities it will be used for in the actual clients environments. This could easily happen with an integration function for synchronization that would work with any entity. It would be nice to deliver a configuration entity to allow the customer to configure what entities shall be synchronized.
In such a case the configuration entity would include a parental lookup to _mwo_pluginstepregistration_ and manipulate the attached record. This eases management compared to direct registration as a standard custom entity can be managed via a lookup, while the actual registration requires knowledge about the registration system and also requires management of the image. 
You would need to worry about _sdkmessage_, _sdkmessagefilters_, _sdkmessageprocessingstep_, _sdkmessageprocessingstepimage_ and _plugintype_ which all cant be stored as lookups. 

With this solution its only one custom entity where you intuitively enter your registration values and the rest is handled inside that entity.
This is the same principle as the CrmPluginRegistrationAttribute of the [spkl](https://github.com/scottdurow/SparkleXrm/tree/master/spkl) project. The Attribute poses an abstraction layer where you are still obliged to enter correct values, but the little quirks of the Microsoft plugin entities are abstracted to give you an easy way to create a registration. This proect tries to do the same, just as an entity instead of code, focusing on runtime rather than design time.

The before mentioned configuration record would create and update or (de)activate the _mwo_pluginstepregistration_ record. Deletion could be handled by the relationship. For every configuration record there would then be at least one _mwo_pluginstepregistration_ record managing a step registering the plugintype (implementation of IPlugin) to a message. Your integration function can then be registered for lets say the entity contact by just creating a configuration specifying the contact, that creates three _mwo_pluginstepregistration_ records for Create, Update and Delete of contact, referencing the integration function and when the customer wants to stop synchronizing contacts he just deletes the configuration, unregistering the steps again.

I plan to use this myself for creating a "name-combiner" that allows people to implement the standard requirement of "I want these x fields to be concatenated as the primary field of this entity" with no code. Obviously the registrations can only be determined at runtime unless you would register on every entities Create and Update and then checking based on the name combiner configuration skip execution for all other cases. It is clear that this would yield a performance penalty for all entities, so the runtime registration will be a big enabler for this idea.

## Details
Check the [wiki](https://github.com/Kunter-Bunt/D365LivePluginRegistration/wiki) for details on the entity. 

## License
**MIT**  
