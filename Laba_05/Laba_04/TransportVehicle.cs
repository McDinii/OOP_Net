using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_05
{
    public abstract class TransportVehicle
    {
        public int CountPassengers;

        protected TransportVehicle(int countPassengers)
        {
            CountPassengers = countPassengers;
        }

        public override string ToString()
        {
            return $"this transport have {CountPassengers} count passengers";
        }
    }
}
