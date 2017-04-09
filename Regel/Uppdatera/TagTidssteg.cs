using Regel.Ingång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regel.Utgång;
using Entitet;
using Entitet.Undantag;

namespace Regel.Uppdatera
{
    public class TagTidssteg : ITagTidssteg
    {
        private readonly ISpelarhandling _spelarhandling;
        private readonly ISpelvärld _spelvärld;
        private readonly FlyttaSpelarobjekt _flyttaSpelarobjekt;

        public TagTidssteg(ISpelarhandling spelarhandling, ISpelvärld spelvärld, FlyttaSpelarobjekt flyttaSpelarobjekt)
        {
            _spelarhandling = spelarhandling ?? throw new UndantagFörSaknatKrav("TagTidssteg måste skapas med spelarhandling.");
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("TagTidssteg måste skapas med spelvärld.");
            _flyttaSpelarobjekt = flyttaSpelarobjekt;
        }

        public void Tick()
        {
            _flyttaSpelarobjekt.Flytta();
        }
    }
}
