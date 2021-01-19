using Microsoft.Xrm.Sdk;
using mwo.LiveRegistration.Plugins.Models;

namespace mwo.LiveRegistration.Plugins
{
    /// <summary>
    /// Extentions for the base type int.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Emits the integer as Microsoft.Xrm.Sdk.OptionSetValue.
        /// </summary>
        public static OptionSetValue ToOptionSetValue(this int i)
        {
            return new OptionSetValue(i);
        }
    }
}
