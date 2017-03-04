using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class Visning
    {
        private int _skärmX;
        private int _skärmY;
        private int _skärmLager;
        private int _bildmängdX;
        private int _bildmängdY;
        private int _bredd;
        private int _höjd;

        public Visning(int skärmX, int skärmY, int skärmLager, int bildmängdX, int bildmängdY, int bredd, int höjd)
        {
            _skärmX = skärmX;
            _skärmY = skärmY;
            _skärmLager = skärmLager;
            _bildmängdX = bildmängdX;
            _bildmängdY = bildmängdY;
            _bredd = bredd;
            _höjd = höjd;
        }

        public override bool Equals(object obj)
        {
            var visning = obj as Visning;

            if(visning == null)
            {
                return false;
            }

            return _skärmX.Equals(visning._skärmX) &&
                _skärmY.Equals(visning._skärmY) &&
                _skärmLager.Equals(visning._skärmLager) &&
                _bildmängdX.Equals(visning._bildmängdX) &&
                _bildmängdY.Equals(visning._bildmängdY) &&
                _bredd.Equals(visning._bredd) &&
                _höjd.Equals(visning._höjd);
        }

        public override int GetHashCode()
        {
            var hash = 23;
            hash = hash * 31 + _skärmX;
            hash = hash * 31 + _skärmY;
            hash = hash * 31 + _skärmLager;
            hash = hash * 31 + _bildmängdX;
            hash = hash * 31 + _bildmängdY;
            hash = hash * 31 + _bredd;
            hash = hash * 31 + _höjd;
            return hash;
        }

        public override string ToString()
        {
            return $"{_skärmX} {_skärmY} {_skärmLager} {_bildmängdX} {_bildmängdY} {_bredd} {_höjd}";
        }
    }
}
