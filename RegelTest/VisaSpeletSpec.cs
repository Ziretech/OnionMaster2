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
