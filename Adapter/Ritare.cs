﻿using Entitet.Undantag;
using Regel;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Ritare : IRitare
    {
        private readonly IGrafik _grafik;

        public Ritare(IGrafik grafik)
        {
            _grafik = grafik ?? throw new UndantagFörSaknatKrav("Grafik får inte vara null.");
        }

        public void KopieraBildTillSkärmen(int skärmX, int skärmY, int bildmängdX, int bildmängdY, int bredd, int höjd)
        {
            _grafik.KopieraTexturrektangelTillRityta(bildmängdX, bildmängdY, skärmX, skärmY, bredd, höjd);
        }
    }
}
