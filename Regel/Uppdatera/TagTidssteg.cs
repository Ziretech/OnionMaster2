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
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("TagTidssteg måste skapas med spelvärld.");
        }

        public void Tick()
        {
            // för varje handling

            // för varje objekt som har ett kontroll-objekt
            // för varje kontroll-objekt som har en action kopplad till 

            var flyttaSpelarobjekt = new FlyttaSpelarobjekt(_spelvärld, _spelarhandling);
            flyttaSpelarobjekt.Flytta();
        }
    }
}
