using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bild
    {
        private readonly Bildmängdskoordinat bildmängdskoordinat;
        private readonly Bildstorlek bildmängdsstorlek;

        public Bildmängdskoordinat Bildmängdskoordinat
        {
            get { return bildmängdskoordinat; }
        }

        public Bildstorlek Bildmängdsstorlek
        {
            get { return bildmängdsstorlek; }
        }

        public Bild(Bildmängdskoordinat bildmängdskoordinat, Bildstorlek bildmängdsstorlek)
        {
            this.bildmängdskoordinat = bildmängdskoordinat;
            this.bildmängdsstorlek = bildmängdsstorlek;
        }
        
    }
}
