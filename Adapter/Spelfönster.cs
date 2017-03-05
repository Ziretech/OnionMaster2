using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Entitet;

namespace Adapter
{
    public class Spelfönster
    {
        private GameWindow _gameWindow;
        private readonly double _uppdateringarISekunden;
        private readonly IGrafik _grafik;
        private readonly Bitmap _textur;

        public Spelfönster(GameWindow gameWindow, IGrafik grafik, Bitmap textur)
        {
            _gameWindow = gameWindow;
            _grafik = grafik;
            _textur = textur;

            _gameWindow.Load += Ladda;
            _gameWindow.Resize += ÄndraStorlek;
            _gameWindow.UpdateFrame += Tick;
            _gameWindow.RenderFrame += Visa;

            _uppdateringarISekunden = 30.0;
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
            _grafik.KopieraTexturrektangelTillRityta(0, 0, 50, 50, 32, 32);
            _gameWindow.SwapBuffers();
        }
    }
}
