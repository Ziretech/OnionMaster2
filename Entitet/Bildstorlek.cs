using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bildstorlek
    {
        private readonly int _bredd;
        private readonly int _höjd;

        public int Bredd
        {
            get { return _bredd; }
        }

        public int Höjd
        {
            get { return _höjd; }
        }

        public Bildstorlek(int bredd, int höjd)
        {
            _bredd = bredd;
            _höjd = höjd;
        }
    }
}
