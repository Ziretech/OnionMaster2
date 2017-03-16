using Moq;
using NUnit.Framework;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Visa
{
    [TestFixture]
    public class VisningBeskrivning
    {
        [Test]
        public void Visning_borde_tycka_att_två_likadana_visningar_är_likvärdiga()
        {
            var visning = new Visning(1, 2, 3, 4, 5, 6, 7);
            Assert.That(visning.Equals(new Visning(1, 2, 3, 4, 5, 6, 7)));
            Assert.That(visning, Is.EqualTo(new Visning(1, 2, 3, 4, 5, 6, 7)));
        }

        [Test]
        public void Visning_borde_tycka_att_två_olika_visningar_INTE_är_likvärdiga()
        {
            var visning = new Visning(1, 2, 3, 4, 5, 6, 7);
            Assert.That(!visning.Equals(new Visning(2, 2, 3, 4, 5, 6, 7)));
            Assert.That(visning, Is.Not.EqualTo(new Visning(1, 3, 3, 4, 5, 6, 7)));
        }

        [Test]
        public void Visning_borde_visas_i_text()
        {
            var visning = new Visning(1, 2, 3, 4, 5, 6, 7);
            Assert.That(visning.ToString(), Is.EqualTo("1 2 3 4 5 6 7"));
        }

        [Test]
        public void Visning_borde_kopiera_bild_till_skärmen()
        {
            var ritareMock = new Mock<IRitare>();
            var visning = new Visning(11, 12, 13, 14, 15, 16, 17);
            visning.Visa(ritareMock.Object);
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(11, 12, 14, 15, 16, 17));
        }
    }
}
