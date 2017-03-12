using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class Visning
    {
        private readonly int _skärmX;
        private readonly int _skärmY;
        public readonly int Skärmlager;
        private readonly int _bildmängdX;
        private readonly int _bildmängdY;
        private readonly int _bredd;
        private readonly int _höjd;

        public Visning(int skärmX, int skärmY, int skärmLager, int bildmängdX, int bildmängdY, int bredd, int höjd)
        {
            _skärmX = skärmX;
            _skärmY = skärmY;
            Skärmlager = skärmLager;
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
                Skärmlager.Equals(visning.Skärmlager) &&
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
            hash = hash * 31 + Skärmlager;
            hash = hash * 31 + _bildmängdX;
            hash = hash * 31 + _bildmängdY;
            hash = hash * 31 + _bredd;
            hash = hash * 31 + _höjd;
            return hash;
        }

        public void Visa(IRitare ritare)
        {
            ritare.KopieraBildTillSkärmen(_skärmX, _skärmY, _bildmängdX, _bildmängdY, _bredd, _höjd);
        }

        public override string ToString()
        {
            return $"{_skärmX} {_skärmY} {Skärmlager} {_bildmängdX} {_bildmängdY} {_bredd} {_höjd}";
        }
    }
}
