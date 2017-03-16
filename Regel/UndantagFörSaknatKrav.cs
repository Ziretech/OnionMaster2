using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class UndantagFörSaknatKrav : Exception
    {
        public UndantagFörSaknatKrav() : base() { }

        public UndantagFörSaknatKrav(string meddelande) : base(meddelande) { }

        public UndantagFörSaknatKrav(string meddelande, Exception inreUndantag) : base(meddelande, inreUndantag) { }
    }
}
