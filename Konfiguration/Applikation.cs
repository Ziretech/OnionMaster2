using Adapter;
using Entitet;
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
            var spelvärld = new Spelvärld();
            spelvärld.LäggTill(new Objekt { Position = new Position(50, 50, 0), Bild = new Bild(new Bildmängdskoordinat(0, 0), new Bildstorlek(32, 32)) });
            Spelfönster fönster = new Spelfönster(new GameWindow(), grafik, new Bitmap("c:/temp/tiles.png"), new RegelFabrik(), spelvärld);
            fönster.Öppna();
        }
    }
}
