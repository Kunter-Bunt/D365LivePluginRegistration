using Microsoft.Xrm.Sdk;
using System;

namespace mwo.LiveRegistration.Plugins.Extensions
{
    /// <summary>
    /// Extensions for the class Microsoft.Xrm.Sdk.Entity
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Merges an additional entity on top of the base entity, overwriting attributes that are present in the additionla entity.
        /// </summary>
        public static Entity Merge(this Entity baseEnt, Entity additionalEnt)
        {
            if (baseEnt == null) throw new ArgumentNullException(nameof(baseEnt));
            if (additionalEnt == null) throw new ArgumentNullException(nameof(additionalEnt));

            var mergedEnt = new Entity(baseEnt.LogicalName, baseEnt.Id);
            mergedEnt.Attributes.AddRange(baseEnt.Attributes);
            foreach (var attr in additionalEnt.Attributes) mergedEnt.Attributes[attr.Key] = attr.Value;
            return mergedEnt;
        }
    }
}
