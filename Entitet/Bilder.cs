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
            return new Bild(new Bildmängdskoordinat(3, 3), new Bildstorlek(3, 3));
        }
    }
}
