using Entitet.Undantag;
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
            Position = position ?? throw new UndantagFörSaknatKrav("Bildruta måste ha en position.");
        }

        public override string ToString()
        {
            return $"{Bildindex}@{Visningstid} {Position.X},{Position.Y},{Position.Z}";
        }

        public override bool Equals(object obj)
        {
            var bildruta = (Bildruta) obj;
            return bildruta != null &&
                bildruta.Visningstid == Visningstid &&
                bildruta.Bildindex == Bildindex && 
                Position.Equals(bildruta.Position);
        }

        public override int GetHashCode()
        {
            return Visningstid ^ Bildindex ^ Position.GetHashCode();
        }
    }
}
