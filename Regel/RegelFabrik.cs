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
    public class Regelfabrik : IRegelfabrik
    {
        public ISpelvärld Spelvärld { get; set; }
        public IRitare Ritare { get; set; }
        public ISpelarhandling Spelarhandling { get; set; }

        public IVisaSpelet SkapaVisaSpelet()
        {
            return new VisaSpelet(Ritare, Spelvärld);
        }

        public ITagTidssteg SkapaTagTidssteg()
        {
            return new TagTidssteg(Spelarhandling, Spelvärld);
        }
    }
}
