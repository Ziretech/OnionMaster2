using Entitet;
using Regel.Uppdatera;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Ingång
{
    public interface IRegelFabrik
    {
        IVisaSpelet SkapaVisaSpelet();
        ITagTidssteg SkapaTagTidssteg(ISpelarhandling spelarhandling);
    }
}
