using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Entitet;
using Regel;
using Regel.Utgång;
using Regel.Ingång;

namespace Adapter
{
    public class Spelfönster
    {
        private GameWindow _gameWindow;
        private readonly double _uppdateringarISekunden;
        private readonly IGrafik _grafik;
        private readonly IRitare _ritare;
        private readonly Bitmap _textur;
        private readonly ISpelvärld _spelvärld;
        private readonly IRegelFabrik _regelfabrik;
        private readonly ISpelarhandling _spelarhandling;

        public Spelfönster(GameWindow gameWindow, IGrafik grafik, ISpelarhandling spelarhandling, Bitmap textur, IRegelFabrik regelfabrik, ISpelvärld spelvärld)
        {
            _gameWindow = gameWindow;
            _grafik = grafik;
            _textur = textur;
            _ritare = new Ritare(_grafik);
            _regelfabrik = regelfabrik;
            _spelvärld = spelvärld;
            _spelarhandling = spelarhandling;

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
            _regelfabrik.SkapaTagTidssteg(_spelarhandling, _spelvärld).Tick();
        }

        private void Visa(object sender, FrameEventArgs e)
        {
            _grafik.TömRityta();
            _regelfabrik.SkapaVisaSpelet(_ritare, _spelvärld).Visa();
            _gameWindow.SwapBuffers();
        }
    }
}
