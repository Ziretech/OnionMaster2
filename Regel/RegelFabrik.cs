using Entitet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class RegelFabrik : IRegelFabrik
    {
        public IVisaSpelet SkapaVisaSpelet(IRitare ritare, Spelvärld spelvärld)
        {
            return new VisaSpelet(ritare, spelvärld);
        }
    }
}
