using Adapter;
using OpenTK;
using Regel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konfiguration
{
    public class Applikation
    {
        static void Main(string[] args)
        {
            var grafik = new OpenGLGrafik();
            Spelfönster fönster = new Spelfönster(new GameWindow(), grafik, new Bitmap("c:/temp/tiles.png"), new RegelFabrik());
            fönster.Öppna();
        }
    }
}
