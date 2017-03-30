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

        public override string ToString()
        {
            return $"[{bildmängdskoordinat.X},{bildmängdskoordinat.Y} {bildmängdsstorlek.Bredd}x{bildmängdsstorlek.Höjd}]";
        }

        public override bool Equals(object obj)
        {
            var bild = (Bild)obj;
            return bild != null &&
                bildmängdskoordinat.X == bild.bildmängdskoordinat.X &&
                bildmängdskoordinat.Y == bild.bildmängdskoordinat.Y &&
                bildmängdsstorlek.Bredd == bild.bildmängdsstorlek.Bredd &&
                bildmängdsstorlek.Höjd == bild.bildmängdsstorlek.Höjd;
        }

        public override int GetHashCode()
        {
            return bildmängdskoordinat.X ^
                bildmängdskoordinat.Y ^
                bildmängdsstorlek.Bredd ^
                bildmängdsstorlek.Höjd;
        }
    }
}
