using Adapter;
using OpenTK;
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
            Spelfönster fönster = new Spelfönster(new GameWindow(), new OpenGLGrafik(), new Bitmap("c:/temp/tiles.png"));
            fönster.Öppna();
        }
    }
}
