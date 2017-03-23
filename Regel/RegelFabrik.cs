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
        public ISpelvärld Spelvärld { get; set; }
        public IRitare Ritare { get; set; }

        public IVisaSpelet SkapaVisaSpelet()
        {
            return new VisaSpelet(Ritare, Spelvärld);
        }

        public ITagTidssteg SkapaTagTidssteg(ISpelarhandling spelarhandling)
        {
            return new TagTidssteg(spelarhandling, Spelvärld);
        }
    }
}
