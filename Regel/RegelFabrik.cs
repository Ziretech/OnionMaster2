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
        private readonly IRitare _ritare;

        public RegelFabrik(ISpelvärld spelvärld, IRitare ritare)
        {
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("RegelFabrik behöver spelvärld för att skapas.");
            _ritare = ritare ?? throw new UndantagFörSaknatKrav("RegelFabrik behöver ritare för att skapas.");
        }

        public IVisaSpelet SkapaVisaSpelet()
        {
            return new VisaSpelet(_ritare, _spelvärld);
        }

        public ITagTidssteg SkapaTagTidssteg(ISpelarhandling spelarhandling)
        {
            return new TagTidssteg(spelarhandling, _spelvärld);
        }
    }
}
