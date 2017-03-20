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
        public IVisaSpelet SkapaVisaSpelet(IRitare ritare, ISpelvärld spelvärld)
        {
            return new VisaSpelet(ritare, spelvärld);
        }

        public ITagTidssteg SkapaTagTidssteg(ISpelarhandling spelarhandling, ISpelvärld spelvärld)
        {
            return new TagTidssteg(spelarhandling, spelvärld);
        }
    }
}
