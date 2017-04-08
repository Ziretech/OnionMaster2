using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bildruta
    {
        public int Visningstid { get; }
        public int Bildindex { get; }
        public Position Position { get; }

        public Bildruta(int visningstid, int bildindex, Position position)
        {
            Visningstid = visningstid;
            Bildindex = bildindex;
            Position = position;
        }
    }
}
