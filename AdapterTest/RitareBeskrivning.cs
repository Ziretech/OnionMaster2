using Moq;
using NUnit.Framework;
using Regel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    [TestFixture]
    public class RitareBeskrivning
    {
        [Test]
        public void Ritare_borde_kopiera_bild_till_skärmen()
        {
            var grafikMock = new Mock<IGrafik>();
            var ritare = new Ritare(grafikMock.Object);
            ritare.KopieraBildTillSkärmen(3, 4, 1, 2, 5, 6);
            grafikMock.Verify(grafik => grafik.KopieraTexturrektangelTillRityta(1, 2, 3, 4, 5, 6));
        }

        [Test]
        public void Ritare_kan_inte_skapas_utan_grafik()
        {
            try
            {
                var ritare = new Ritare(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörNull undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("grafik"));
            }            
        }
    }
}
