using Entitet;
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
        IVisaSpelet SkapaVisaSpelet(IRitare ritare, Spelvärld spelvärld);
    }
}
