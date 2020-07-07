using mwo.LiveRegistration.Plugins.Models;

namespace mwo.LiveRegistration.Plugins.Interfaces
{
    interface ICRMExecutable
    {
        void Execute(IContext context);
    }
}
