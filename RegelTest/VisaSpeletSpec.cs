using Entitet;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    [TestFixture]
    public class VisaSpeletSpec
    {
        [Test]
        public void VisaSpelet_borde_inte_visa_någonting_när_spelvärlden_är_tom()
        {
            var ritareMock = new Mock<IRitare>();
            var spelvärld = new Spelvärld();
            VisaSpelet(ritareMock.Object, spelvärld).Visa();
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void VisaSpelet_borde_visa_en_bild()
        {
            var ritareMock = new Mock<IRitare>();
            var spelvärld = SkapaSpelvärld(new Objekt { Position = new Position(1, 2, 3), Bild = new Bild(new Bildmängdskoordinat(4, 5), new Bildstorlek(6, 7)) });
            VisaSpelet(ritareMock.Object, spelvärld).Visa();
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(1, 2, 4, 5, 6, 7));
        }

        [Test]
        public void VisaSpelet_borde_visa_två_bilder()
        {
            var ritareMock = new Mock<IRitare>();
            var spelvärld = SkapaSpelvärld(
                new Objekt { Position = new Position(1, 2, 3), Bild = new Bild(new Bildmängdskoordinat(4, 5), new Bildstorlek(6, 7)) },
                new Objekt { Position = new Position(1, 2, 3), Bild = new Bild(new Bildmängdskoordinat(4, 5), new Bildstorlek(6, 7)) });
            VisaSpelet(ritareMock.Object, spelvärld).Visa();
            ritareMock.Verify(ritare => ritare.KopieraBildTillSkärmen(1, 2, 4, 5, 6, 7), Times.AtLeast(2));
        }

        [Test]
        public void VisaSpelet_gör_undantag_för_när_ritare_är_null()
        {
            try
            {
                VisaSpelet(null, new Spelvärld());
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörNull undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("ritare"));
            }
        }

        [Test]
        public void VisaSpelet_gör_undantag_för_när_spelvärld_är_null()
        {
            try
            {
                var ritareMock = new Mock<IRitare>();
                VisaSpelet(ritareMock.Object, null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (UndantagFörNull undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärld"));
            }
        }

        private IVisaSpelet VisaSpelet(IRitare ritare, Spelvärld spelvärld)
        {
            return new RegelFabrik().SkapaVisaSpelet(ritare, spelvärld);
        }

        private Spelvärld SkapaSpelvärld(params Objekt[] lista)
        {
            var spelvärld = new Spelvärld();
            foreach(var objekt in lista)
            {
                spelvärld.LäggTill(objekt);
            }
            return spelvärld;
        }
    }
}
