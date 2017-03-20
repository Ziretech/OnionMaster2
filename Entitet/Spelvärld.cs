using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Spelvärld : ISpelvärld
    {
        List<Objekt> _objektlista;
        Objekt _spelarkaraktären;

        public Spelvärld()
        {
            _objektlista = new List<Objekt>();
        }

        public void LäggTill(Objekt objekt, Objekttyp typ = Objekttyp.InteSpecificerat)
        {
            _objektlista.Add(objekt);
            if(typ == Objekttyp.Spelarkaraktären)
            {
                _spelarkaraktären = objekt;
            }            
        }

        public int AntalObjekt()
        {
            return _objektlista.Count;
        }

        public IEnumerable<Objekt> HämtaObjekt(Func<Objekt, bool> filterfunktion)
        {
            return _objektlista.Where(filterfunktion);
        }

        public Objekt HämtaSpelarKaraktären()
        {
            return _spelarkaraktären;
        }
    }
}
