using Microsoft.Xrm.Sdk;
using System;

namespace mwo.LiveRegistration.Plugins.Extensions
{
    public static class EntityExtensions
    {
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
