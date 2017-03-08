using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;

namespace Regel
{
    class VisaSpelet : IVisaSpelet
    {
        private readonly Spelvärld _spelvärld;
        private readonly IRitare _ritare;

        public VisaSpelet(IRitare ritare, Spelvärld spelvärld)
        {
            _ritare = ritare;
            _spelvärld = spelvärld;
        }

        public void Visa()
        {
            var visningar = new VisaBilder(_spelvärld).HämtaVisningar();
            visningar.Visa(_ritare);
        }
    }
}
