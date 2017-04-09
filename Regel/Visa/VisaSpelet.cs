using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;
using Regel.Ingång;
using Regel.Utgång;
using Entitet.Undantag;

namespace Regel.Visa
{
    public class VisaSpelet : IVisaSpelet
    {
        private readonly ISpelvärld _spelvärld;
        private readonly IRitare _ritare;
        private readonly VisaBilder _visaBilder;

        public VisaSpelet(IRitare ritare, ISpelvärld spelvärld, VisaBilder visaBilder)
        {
            _ritare = ritare ?? throw new UndantagFörSaknatKrav("VisaSpelet får inte skapas utan ritare.");
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("VisaSpelet får inte skapas utan spelvärld.");
            _visaBilder = visaBilder;
        }

        public void Visa()
        {
            var visningar = _visaBilder.HämtaVisningar();
            visningar.Visa(_ritare);
        }
    }
}
