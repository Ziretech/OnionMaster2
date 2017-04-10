using Entitet.Undantag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bildrutor
    {
        private List<Bildruta> _bildrutor;

        public Bildrutor(List<Bildruta> bildrutor)
        {
            _bildrutor = bildrutor ?? throw new UndantagFörSaknatKrav("Bildrutor måste ha en lista med bildrutor.");
        }

        public int Antal
        {
            get
            {
                return _bildrutor.Count;
            }
        }

        public override string ToString()
        {
            var beskrivning = "[";
            foreach(var bildruta in _bildrutor)
            {
                beskrivning += (beskrivning.Length > 1 ? ";" : "") + bildruta.ToString();
            }
            return beskrivning + "]";
        }

        public override int GetHashCode()
        {
            var kod = 0;
            foreach(var bildruta in _bildrutor)
            {
                kod += bildruta.GetHashCode();
            }
            return kod;
        }

        public override bool Equals(object obj)
        {
            var bildrutor = (Bildrutor)obj;
            var lika = bildrutor != null && bildrutor._bildrutor.Count == _bildrutor.Count;
            for(int i = 0; i < _bildrutor.Count && lika; i++)
            {
                lika = _bildrutor[i].Equals(bildrutor._bildrutor[i]);
            }
            return lika;
        }
    }
}
