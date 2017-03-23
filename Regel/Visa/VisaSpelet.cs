using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;
using Regel.Ingång;
using Regel.Utgång;

namespace Regel.Visa
{
    class VisaSpelet : IVisaSpelet
    {
        private readonly ISpelvärld _spelvärld;
        private readonly IRitare _ritare;

        public VisaSpelet(IRitare ritare, ISpelvärld spelvärld)
        {
            _ritare = ritare ?? throw new UndantagFörSaknatKrav("VisaSpelet får inte skapas utan ritare.");
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("VisaSpelet får inte skapas utan spelvärld.");
        }

        public void Visa()
        {
            var visningar = new VisaBilder(_spelvärld).HämtaVisningar();
            visningar.Visa(_ritare);
        }
    }
}
