using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_07
{
    internal interface ISeteable<T>
    {
        void Add(T item);
        void Remove(T item);
        void View();
    }
}
