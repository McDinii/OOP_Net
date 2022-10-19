using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_04
{
    public abstract class TransportVehicle // абстрактный класс
    {
        public int CountPassengers;

        protected TransportVehicle(int countPassengers)
        {
            CountPassengers = countPassengers;
        }

        public override string ToString() // переопределяем метод 
        {
            return $"this transport have {CountPassengers} count passengers";
        }
    }
}
