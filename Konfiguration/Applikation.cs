using Adapter;
using Entitet;
using Microsoft.Practices.Unity;
using OpenTK;
using Regel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Regel.Utgång;
using Regel.Ingång;
using OpenTK.Input;
using Regel.Uppdatera;
using Regel.Visa;

namespace Konfiguration
{
    public class Applikation
    {
        static void Main(string[] args)
        {
            var objektbehållare = new UnityContainer();

            var openTKFönster = new GameWindow();
            objektbehållare.RegisterInstance(openTKFönster);
            objektbehållare.RegisterInstance<IGrafik>(new OpenGLGrafik());
            objektbehållare.RegisterType<IRitare, Ritare>();
            objektbehållare.RegisterInstance(SkapaSpelvärld());
            objektbehållare.RegisterInstance(openTKFönster.Keyboard);
            objektbehållare.RegisterType<ISpelarhandling, Interaktionsadapter>();
            objektbehållare.RegisterInstance(new Bitmap("c:/temp/tiles.png"));
            objektbehållare.RegisterType<ITagTidssteg, TagTidssteg>();
            objektbehållare.RegisterType<IVisaSpelet, VisaSpelet>();

            objektbehållare.Resolve<Spelfönster>().Öppna();
        }

        private static ISpelvärld SkapaSpelvärld()
        {
            var tile = new Bildstorlek(32, 32);

            var väggar = new int[][]
            {
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 2, 2, 2, 1 },
                new int[] { 1, 2, 2, 2, 1 },
                new int[] { 1, 2, 2, 2, 1 },
                new int[] { 1, 1, 1, 1, 1 }
            };

            var spelvärld = new Spelvärld();

            var spelarkaraktär = new Objekt { Position = new Position(3 * 32, 3 * 32, 1), Bild = new Bild(new Bildmängdskoordinat(0, 0), new Bildstorlek(32, 32)) };
            spelvärld.LäggTill(spelarkaraktär, Objekttyp.Spelarkaraktären);

            for (var y = 0; y < 5; y++)
            {
                for(var x = 0; x < 5; x++)
                {
                    if(väggar[x][y] == 1)
                    {
                        spelvärld.LäggTill(new Objekt { Position = new Position(x * 32, y * 32, 0), Bild = new Bild(new Bildmängdskoordinat(1 * 32, 3 * 32), tile) });
                    }
                    else if(väggar[x][y] == 2)
                    {
                        spelvärld.LäggTill(new Objekt { Position = new Position(x * 32, y * 32, 0), Bild = new Bild(new Bildmängdskoordinat(0 * 32, 3 * 32), tile) });
                    }
                }
            }

            
            return spelvärld;
        }
    }
}
