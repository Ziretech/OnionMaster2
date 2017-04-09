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
            _bildrutor = bildrutor;
        }

        public int Antal
        {
            get
            {
                return _bildrutor.Count;
            }
        }
    }
}
