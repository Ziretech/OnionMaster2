using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class BildrutaBeskrivning
    {
        [Test]
        public void Bildruta_borde_ha_egenskapen_visningstid()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Visningstid, Is.EqualTo(1));
        }

        [Test]
        public void Bildruta_borde_ha_egenskapen_bildindex()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Bildindex, Is.EqualTo(2));
        }

        [Test]
        public void Bildruta_borde_ha_egenskapen_position()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Position, Is.EqualTo(new Position(3, 4, 5)));
        }
    }
}
