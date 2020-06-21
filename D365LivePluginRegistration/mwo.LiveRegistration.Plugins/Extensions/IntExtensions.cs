using Microsoft.Xrm.Sdk;

namespace mwo.LiveRegistration.Plugins
{
    static class IntExtensions
    {
        public static OptionSetValue ToOptionSetValue(this int i)
        {
            return new OptionSetValue(i);
        }
    }
}
