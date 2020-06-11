using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwo.LiveRegistration.Plugins
{
    public enum Stage
    {
        PreValidation = 10,
        PreOperation = 20,
        PostOperation = 40,
    }
}
