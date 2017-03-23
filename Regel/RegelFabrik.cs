using Entitet;
using Regel.Ingång;
using Regel.Uppdatera;
using Regel.Utgång;
using Regel.Visa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class RegelFabrik : IRegelFabrik
    {
        private readonly ISpelvärld _spelvärld;

        public RegelFabrik(ISpelvärld spelvärld)
        {
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("RegelFabrik behöver spelvärld för att skapas.");
        }

        public IVisaSpelet SkapaVisaSpelet(IRitare ritare)
        {
            return new VisaSpelet(ritare, _spelvärld);
        }

        public ITagTidssteg SkapaTagTidssteg(ISpelarhandling spelarhandling)
        {
            return new TagTidssteg(spelarhandling, _spelvärld);
        }
    }
}
