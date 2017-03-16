using Regel.Ingång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regel.Utgång;
using Entitet;

namespace Regel.Uppdatera
{
    public class TagTidssteg : ITagTidssteg
    {
        private readonly ISpelarhandling _spelarhandling;
        private readonly ISpelvärld _spelvärld;

        public TagTidssteg(ISpelarhandling spelarhandling, ISpelvärld spelvärld)
        {
            _spelarhandling = spelarhandling ?? throw new UndantagFörSaknatKrav("TagTidssteg måste skapas med spelarhandling.");
            _spelvärld = spelvärld;
        }

        public void Tick(ISpelarhandling spelarhandling)
        {
            if(spelarhandling.FlyttaUpp())
            {
                var flyttaSpelarobjekt = new FlyttaSpelarobjekt(_spelvärld);
                flyttaSpelarobjekt.FlyttaUpp();
            }            
        }
    }
}
