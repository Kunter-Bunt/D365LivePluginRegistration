using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins
{
    /// <summary>
    /// Extentions for the base type int.
    /// </summary>
    static class IntExtensions
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
