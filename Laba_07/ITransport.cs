using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_07
{
    public interface ITransport
    {

        void Launch();
        void Shutdown();
        bool ReadinessСheck();
        void Drive();
        void SpeedControl();
    }
}
