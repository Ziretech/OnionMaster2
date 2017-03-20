using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace Adapter
{
    public class Interaktionsadapter : ISpelarhandling
    {
        private readonly KeyboardDevice _tangentbord;

        public Interaktionsadapter(KeyboardDevice tangentbord)
        {
            this._tangentbord = tangentbord;
        }

        public bool FlyttaHöger()
        {
            return _tangentbord[Key.Right];
        }

        public bool FlyttaNer()
        {
            return _tangentbord[Key.Down];
        }

        public bool FlyttaUpp()
        {
            return _tangentbord[Key.Up];
        }

        public bool FlyttaVänster()
        {
            return _tangentbord[Key.Left];
        }
    }
}
