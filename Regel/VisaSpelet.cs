using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;
using Regel.Ingång;
using Regel.Utgång;

namespace Regel
{
    class VisaSpelet : IVisaSpelet
    {
        private readonly Spelvärld _spelvärld;
        private readonly IRitare _ritare;

        public VisaSpelet(IRitare ritare, Spelvärld spelvärld)
        {
            if(ritare == null)
            {
                throw new UndantagFörNull("Ritare får inte vara null.");
            }
            _ritare = ritare;

            if (spelvärld == null)
            {
                throw new UndantagFörNull("Spelvärld får inte vara null.");
            }
            _spelvärld = spelvärld;
        }

        public void Visa()
        {
            var visningar = new VisaBilder(_spelvärld).HämtaVisningar();
            visningar.Visa(_ritare);
        }
    }
}
