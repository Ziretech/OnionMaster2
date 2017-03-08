using Entitet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public interface IRegelFabrik
    {
        IVisaSpelet SkapaVisaSpelet(IRitare ritare, Spelvärld spelvärld);
    }
}
