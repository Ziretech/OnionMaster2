using Entitet;
using Entitet.Undantag;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Uppdatera
{
    public class FlyttaSpelarobjekt
    {
        private readonly ISpelvärld _spelvärld;
        private readonly Objekt _spelarkaraktär;
        private readonly ISpelarhandling _spelarhandling;

        public FlyttaSpelarobjekt(ISpelvärld spelvärld, ISpelarhandling spelarhandling)
        {
            _spelvärld = spelvärld ?? throw new UndantagFörSaknatKrav("FlyttaSpelarobjekt måste skapas med spelvärld.");
            _spelarkaraktär = _spelvärld.HämtaSpelarKaraktären();
            _spelarhandling = spelarhandling ?? throw new UndantagFörSaknatKrav("FlyttaSpelarobjekt måste skapas med spelarhandling.");
        }

        public void Flytta()
        {            
            var distans = 2;

            if (_spelarhandling.FlyttaUpp())
            {
                var tidigare = _spelarkaraktär.Position;
                _spelarkaraktär.Position = new Position(tidigare.X, tidigare.Y + distans, tidigare.Z);
            }
            if (_spelarhandling.FlyttaNer())
            {
                var tidigare = _spelarkaraktär.Position;
                _spelarkaraktär.Position = new Position(tidigare.X, tidigare.Y - distans, tidigare.Z);
            }
            if (_spelarhandling.FlyttaHöger())
            {
                var tidigare = _spelarkaraktär.Position;
                _spelarkaraktär.Position = new Position(tidigare.X + distans, tidigare.Y, tidigare.Z);
            }
            if (_spelarhandling.FlyttaVänster())
            {
                var tidigare = _spelarkaraktär.Position;
                _spelarkaraktär.Position = new Position(tidigare.X - distans, tidigare.Y, tidigare.Z);
            }
        }
    }
}
