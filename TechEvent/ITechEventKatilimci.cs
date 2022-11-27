using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechEvent
{
    internal interface ITechEventKatilimci
    {
        public void BirEtkinligeKatilma(Etkinlik etkinlik);
        public void BiletAl();
    }
}
