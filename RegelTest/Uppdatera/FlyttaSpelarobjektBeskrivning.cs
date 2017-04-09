using Entitet;
using Entitet.Undantag;
using Moq;
using NUnit.Framework;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel.Uppdatera
{
    [TestFixture]
    public class FlyttaSpelarobjektBeskrivning
    {
        private Mock<ISpelarhandling> _spelarhandlingStub;

        private ISpelvärld SkapaSpelvärldMedKaraktärenVid(Position position)
        {
            var spelvärld = new Spelvärld();
            var spelarkaraktär = new Objekt { Position = position };            
            spelvärld.LäggTill(spelarkaraktär, Objekttyp.Spelarkaraktären);
            return spelvärld;
        }

        [SetUp]
        public void Setup()
        {
            _spelarhandlingStub = new Mock<ISpelarhandling>();
        }

        [Test]
        public void Borde_flytta_spelarkaraktären_2_steg_upp_när_spelaren_flyttar_upp()
        {            
            var spelvärld = SkapaSpelvärldMedKaraktärenVid(new Position(1, 2, 3));            
            _spelarhandlingStub.Setup(s => s.FlyttaUpp()).Returns(true);
            new FlyttaSpelarobjekt(spelvärld, _spelarhandlingStub.Object).Flytta();
            Assert.That(spelvärld.HämtaSpelarKaraktären().Position.Y, Is.EqualTo(4));
        }

        [Test]
        public void Borde_flytta_spelarkaraktären_2_steg_ner_när_spelaren_flyttar_ner()
        {
            var spelvärld = SkapaSpelvärldMedKaraktärenVid(new Position(1, 2, 3));
            _spelarhandlingStub.Setup(s => s.FlyttaNer()).Returns(true);
            new FlyttaSpelarobjekt(spelvärld, _spelarhandlingStub.Object).Flytta();
            Assert.That(spelvärld.HämtaSpelarKaraktären().Position.Y, Is.EqualTo(0));
        }

        [Test]
        public void Borde_flytta_spelarkaraktären_2_steg_vänster_när_spelaren_flyttar_vänster()
        {
            var spelvärld = SkapaSpelvärldMedKaraktärenVid(new Position(5, 2, 3));
            _spelarhandlingStub.Setup(s => s.FlyttaVänster()).Returns(true);
            new FlyttaSpelarobjekt(spelvärld, _spelarhandlingStub.Object).Flytta();
            Assert.That(spelvärld.HämtaSpelarKaraktären().Position.X, Is.EqualTo(3));
        }

        [Test]
        public void Borde_flytta_spelarkaraktären_2_steg_höger_när_spelaren_flyttar_höger()
        {
            var spelvärld = SkapaSpelvärldMedKaraktärenVid(new Position(5, 2, 3));
            _spelarhandlingStub.Setup(s => s.FlyttaHöger()).Returns(true);
            new FlyttaSpelarobjekt(spelvärld, _spelarhandlingStub.Object).Flytta();
            Assert.That(spelvärld.HämtaSpelarKaraktären().Position.X, Is.EqualTo(7));
        }

        [Test]
        public void Borde_göra_undantag_från_att_skapas_utan_spelvärld()
        {
            _spelarhandlingStub.Setup(s => s.FlyttaHöger()).Returns(true);
            try
            {
                new FlyttaSpelarobjekt(null, _spelarhandlingStub.Object);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärld"));
            }
        }

        [Test]
        public void Borde_göra_undantag_från_att_skapas_utan_spelarhandling()
        {
            try
            {
                new FlyttaSpelarobjekt(SkapaSpelvärldMedKaraktärenVid(new Position(1, 2, 3)), null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelarhandling"));
            }
        }

        [Test]
        public void Borde_inte_göra_någonting_om_spelvärld_saknar_spelarkaraktär()
        {
            new FlyttaSpelarobjekt(new Spelvärld(), _spelarhandlingStub.Object).Flytta();
        }
    }
}
