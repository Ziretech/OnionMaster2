using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Position
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }

        public int Z
        {
            get { return _z; }
        }

        public Position(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }

        public override bool Equals(object obj)
        {
            var position = (Position)obj;
            return position != null &&
                position.X == X &&
                position.Y == Y &&
                position.Z == Z;
        }

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }
    }
}
