using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class BilderBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<object, string> Strängrepresentationer => new Dictionary<object, string> {
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) }), "Entitet.Bilder" }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}), new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}) }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(9, 2), new Bildstorlek(3, 4))}), new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}) },
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 9), new Bildstorlek(3, 4))}), new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}) },
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(9, 4))}), new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}) },
            { new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 9))}), new Bilder(new List<Bild> { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4))}) }
        };

        [Test]
        public void Bilder_borde_skapas_utan_några_bilder()
        {
            var bilder = new Bilder(new List<Bild>());
            Assert.That(bilder.Antal, Is.EqualTo(0));
        }

        [Test]
        public void Bilder_borde_skapas_med_en_bild()
        {
            var bilder = new Bilder(new List<Bild> { SkapaBild() });
            Assert.That(bilder.Antal, Is.EqualTo(1));
        }

        [Test]
        public void Bilder_borde_skapas_med_två_bilder()
        {
            var bilder = new Bilder(new List<Bild> { SkapaBild(), SkapaBild() });
            Assert.That(bilder.Antal, Is.EqualTo(2));
        }

        [Test]
        public void Bilder_borde_hämta_enda_bilden()
        {
            var endaBilden = SkapaBild(1);
            var bilder = new Bilder(new List<Bild> { endaBilden });
            Assert.That(bilder.HämtaMedIndex(0), Is.EqualTo(endaBilden));
        }

        [Test]
        public void Bilder_borde_hämta_andra_bilden()
        {
            var andraBilden = SkapaBild(3);
            var bilder = new Bilder(new List<Bild> { SkapaBild(2), andraBilden });
            Assert.That(bilder.HämtaMedIndex(1), Is.EqualTo(andraBilden));
        }

        private Bild SkapaBild(int x = 0)
        {
            return new Bild(new Bildmängdskoordinat(x, 2), new Bildstorlek(3, 4));
        }
    }
}
