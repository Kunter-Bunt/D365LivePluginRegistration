using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins.Extensions
{
    public static class EntityExtensions
    {
        public static Entity Merge(this Entity baseEnt, Entity additionalEnt)
        {
            var mergedEnt = new Entity(baseEnt.LogicalName, baseEnt.Id);
            mergedEnt.Attributes.AddRange(baseEnt.Attributes);
            foreach (var attr in additionalEnt.Attributes) mergedEnt.Attributes[attr.Key] = attr.Value;
            return mergedEnt;
        }
    }
}
