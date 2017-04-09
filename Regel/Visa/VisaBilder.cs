using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitet;
using Entitet.Undantag;

namespace Regel.Visa
{
    public class VisaBilder
    {
        private IEnumerable<Objekt> _bilder;

        public VisaBilder(ISpelvärld spelvärld)
        {
            if(spelvärld == null)
            {
                throw new UndantagFörSaknatKrav("Spelvärld får inte vara null.");
            }
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
