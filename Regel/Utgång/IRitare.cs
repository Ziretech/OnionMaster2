using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Utgång
{
    public interface IRitare
    {
        void KopieraBildTillSkärmen(int skärmX, int skärmY, int bildmängdX, int bildmängdY, int bredd, int höjd);
    }
}
