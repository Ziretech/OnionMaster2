using Moq;
using NUnit.Framework;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    [TestFixture]
    public class VisningarSpec
    {
        [Test]
        public void Visningar_borde_inte_visa_när_det_inte_finns_visningar()
        {
            var ritareMock = new Mock<IRitare>();
            var visningar = new Visningar();
            visningar.Visa(ritareMock.Object);
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void Visningar_borde_visa_en_visning()
        {
            var ritareMock = new Mock<IRitare>();
            var visningar = new Visningar();
            visningar.LäggTill(new Visning(1, 2, 3, 4, 5, 6, 7));
            visningar.Visa(ritareMock.Object);
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(1, 2, 4, 5, 6, 7));
        }

        [Test]
        public void Visningar_borde_visa_två_visningar()
        {
            var ritareMock = new Mock<IRitare>();
            var visningar = new Visningar();
            visningar.LäggTill(new Visning(1, 2, 3, 4, 5, 6, 7));
            visningar.LäggTill(new Visning(11, 12, 13, 14, 15, 16, 17));
            visningar.Visa(ritareMock.Object);
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(1, 2, 4, 5, 6, 7));
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(11, 12, 14, 15, 16, 17));
        }

        [Test]
        public void Visningar_borde_göra_undantag_om_null_läggs_till()
        {
            var visningar = new Visningar();
            try
            {
                visningar.LäggTill(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörNull undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("visningar"));
            }            
        }

        [Test]
        public void Visningar_borde_ange_0_antal_visningar()
        {
            var visningar = new Visningar();
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(0));
        }

        [Test]
        public void Visningar_borde_ange_1_visning()
        {
            var visningar = new Visningar();
            visningar.LäggTill(new Visning(1, 2, 3, 4, 5, 6, 7));
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(1));
        }

        [Test]
        public void Visningar_borde_ange_2_visningar()
        {
            var visningar = new Visningar();
            visningar.LäggTill(new Visning(1, 2, 3, 4, 5, 6, 7));
            visningar.LäggTill(new Visning(11, 12, 13, 14, 15, 16, 17));
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(2));
        }
    }
}
