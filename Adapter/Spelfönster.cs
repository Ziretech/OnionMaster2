using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Entitet;
using Regel;

namespace Adapter
{
    public class Spelfönster
    {
        private GameWindow _gameWindow;
        private readonly double _uppdateringarISekunden;
        private readonly IGrafik _grafik;
        private readonly IRitare _ritare;
        private readonly Bitmap _textur;
        private readonly Spelvärld _spelvärld;
        private readonly IRegelFabrik _regelfabrik;

        public Spelfönster(GameWindow gameWindow, IGrafik grafik, Bitmap textur, IRegelFabrik regelfabrik)
        {
            _gameWindow = gameWindow;
            _grafik = grafik;
            _textur = textur;
            _ritare = new Ritare(_grafik);
            _regelfabrik = regelfabrik;

            _gameWindow.Load += Ladda;
            _gameWindow.Resize += ÄndraStorlek;
            _gameWindow.UpdateFrame += Tick;
            _gameWindow.RenderFrame += Visa;

            _uppdateringarISekunden = 30.0;

            _spelvärld = new Spelvärld();
            _spelvärld.LäggTill(new Objekt { Position = new Position(50, 50, 0), Bild = new Bild(new Bildmängdskoordinat(0, 0), new Bildstorlek(32, 32)) });
        }

        public void Öppna()
        {
            _gameWindow.Run(_uppdateringarISekunden);
        }

        public void Stäng()
        {
            _gameWindow.Exit();
        }

        private void Ladda(object sender, EventArgs e)
        {
            _grafik.InitieraGrafik();
            int id = _grafik.LaddaTextur(_textur);
            _grafik.AktiveraTextur(id, _textur.Width, _textur.Height);
        }

        private void ÄndraStorlek(object sender, EventArgs e)
        {
            _grafik.ÄndraStorlek(_gameWindow.Width, _gameWindow.Height);
        }

        private void Tick(object sender, FrameEventArgs e)
        {
        }

        private void Visa(object sender, FrameEventArgs e)
        {
            _regelfabrik.SkapaVisaSpelet(_ritare, _spelvärld).Visa();
            _gameWindow.SwapBuffers();
        }
    }
}
