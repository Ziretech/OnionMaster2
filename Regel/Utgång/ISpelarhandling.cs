using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Utgång
{
    public interface ISpelarhandling
    {
        bool FlyttaUpp();
        bool FlyttaNer();
        bool FlyttaVänster();
        bool FlyttaHöger();
    }
}
