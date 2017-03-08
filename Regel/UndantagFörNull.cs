using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    public class UndantagFörNull : Exception
    {
        public UndantagFörNull() : base() { }

        public UndantagFörNull(string meddelande) : base(meddelande) { }

        public UndantagFörNull(string meddelande, Exception inreUndantag) : base(meddelande, inreUndantag) { }
    }
}
