using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;

namespace Regel
{
    public class VisaBilder
    {
        private IEnumerable<Objekt> _bilder;

        public VisaBilder(Spelvärld spelvärld)
        {
            _bilder = spelvärld.HämtaObjekt(BildVäljare);
        }

        public Visningar HämtaVisningar()
        {
            var visningar = new Visningar();

            foreach(var bild in _bilder)
            {
                visningar.LäggTill(new Visning(
                    bild.Position.X, 
                    bild.Position.Y, 
                    bild.Position.Z, 
                    bild.Bild.Bildmängdskoordinat.X, 
                    bild.Bild.Bildmängdskoordinat.Y, 
                    bild.Bild.Bildmängdsstorlek.Bredd, 
                    bild.Bild.Bildmängdsstorlek.Höjd));
            }

            return visningar;
        }

        private static bool BildVäljare(Objekt objekt)
        {
            return objekt.Bild != null && objekt.Position != null;
        }
    }
}
