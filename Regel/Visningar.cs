using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class Visningar
    {
        private readonly List<Visning> _visningar;

        public Visningar()
        {
            _visningar = new List<Visning>();
        }

        public int AntalVisningar()
        {
            return _visningar.Count;
        }

        public Visning HämtaVisning(int index)
        {
            return _visningar[index];
        }

        public void LäggTill(Visning visning)
        {
            if(visning == null)
            {
                throw new UndantagFörNull("Visning måste vara definierad när det läggs till visningar.");
            }
            _visningar.Add(visning);
        }

        public void Visa(IRitare ritare)
        {
            foreach(var visning in _visningar.OrderBy(visning => visning.Skärmlager))
            {
                visning.Visa(ritare);
            }
        }
    }
}
