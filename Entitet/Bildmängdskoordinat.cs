using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Bildmängdskoordinat
    {
        private readonly int _x;
        private readonly int _y;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public Bildmängdskoordinat(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
