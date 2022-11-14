using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_05
{
    public interface ITransport // определяем интерфейс 
    {

        void Launch(); // метод зажигание
        void Shutdown(); // метод выкл
        bool ReadinessСheck(); // Проверка готовности
        void Drive(); // Ехать 
        void SpeedControl(); // спидометр 
    }
}
