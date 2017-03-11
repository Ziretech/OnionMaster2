using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public interface ISpelvärld
    {
        void LäggTill(Objekt objekt);
        int AntalObjekt();
        IEnumerable<Objekt> HämtaObjekt(Func<Objekt, bool> filterfunktion);
    }
}
