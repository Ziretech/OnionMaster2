using Entitet;
using Entitet.Undantag;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Visa
{
    [TestFixture]
    public class VisaBilderBeskrivning
    {
        [Test]
        public void VisaBilder_borde_inte_generera_visning_för_spelvärld_utan_bilder()
        {
            var spelvärld = new Spelvärld();
            Visningar visningar = new VisaBilder(spelvärld).HämtaVisningar();
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(0));
        }

        [Test]
        public void VisaBilder_borde_generera_visning_för_spelvärld_med_en_bild()
        {
            var spelvärld = new Spelvärld();
            spelvärld.LäggTill(new Objekt { Position = new Position(1, 2, 0), Bild = new Bild(new Bildmängdskoordinat(12, 34), new Bildstorlek(56, 78)) });
            Visningar visningar = new VisaBilder(spelvärld).HämtaVisningar();
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(1));
            Assert.That(visningar.HämtaVisning(0), Is.EqualTo(new Visning(1, 2, 0, 12, 34, 56, 78)));
        }

        [Test]
        public void VisaBilder_borde_generera_visningar_för_spelvärld_med_två_bilder()
        {
            var spelvärld = new Spelvärld();
            spelvärld.LäggTill(new Objekt { Position = new Position(1, 2, 0), Bild = new Bild(new Bildmängdskoordinat(12, 34), new Bildstorlek(56, 78)) });
            spelvärld.LäggTill(new Objekt { Position = new Position(3, 4, 0), Bild = new Bild(new Bildmängdskoordinat(12, 34), new Bildstorlek(56, 78)) });
            Visningar visningar = new VisaBilder(spelvärld).HämtaVisningar();

            Assert.That(visningar.AntalVisningar(), Is.EqualTo(2));
            Assert.That(visningar.HämtaVisning(0), Is.EqualTo(new Visning(1, 2, 0, 12, 34, 56, 78)));
            Assert.That(visningar.HämtaVisning(1), Is.EqualTo(new Visning(3, 4, 0, 12, 34, 56, 78)));
        }

        [Test]
        public void VisaBilder_borde_generera_visningar_för_spelvärld_med_1000_bilder()
        {
            var spelvärld = new Spelvärld();
            for(var i = 0; i < 1000; i++)
            {
                spelvärld.LäggTill(new Objekt { Position = new Position(1, 2, 0), Bild = new Bild(new Bildmängdskoordinat(12, 34), new Bildstorlek(56, 78)) });
            }
            Visningar visningar = new VisaBilder(spelvärld).HämtaVisningar();
            Assert.That(visningar.AntalVisningar(), Is.EqualTo(1000));
        }

        [Test]
        public void VisaBilder_borde_göra_undantag_för_när_det_inte_finns_någon_spelvärld()
        {
            try
            {
                new VisaBilder(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärld"));
            }
        }
    }
}
