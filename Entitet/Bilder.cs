using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bilder
    {
        private readonly List<Bild> _bilder;

        public Bilder(List<Bild> bilder)
        {
            _bilder = bilder;
        }

        public int Antal {
            get
            {
                return _bilder.Count;
            }
        }

        public Bild HämtaMedIndex(int v)
        {
            return _bilder[v];
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach(var bild in _bilder)
            {
                code = code ^ bild.GetHashCode();
            }
            return code;
        }

        public override bool Equals(object obj)
        {
            var bilder = (Bilder)obj;
            var likvärdiga = bilder != null && bilder.Antal == Antal;

            for(var i = 0; i < Antal && likvärdiga; i++)
            {
                likvärdiga = bilder.HämtaMedIndex(i).Equals(HämtaMedIndex(i));
            }
            return likvärdiga;
        }
    }
}
