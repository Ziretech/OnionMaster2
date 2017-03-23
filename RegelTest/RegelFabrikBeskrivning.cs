using Entitet;
using Moq;
using NUnit.Framework;
using Regel.Ingång;
using Regel.Utgång;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regel
{
    [TestFixture]
    public class RegelFabrikBeskrivning
    {
        [Test]
        public void RegelFabrik_borde_skapa_VisaSpelet()
        {
            var ritareMock = new Mock<IRitare>();
            var visaSpelet = new RegelFabrik { Spelvärld = new Spelvärld(), Ritare = ritareMock.Object }.SkapaVisaSpelet();
            Assert.That(visaSpelet, Is.InstanceOf(typeof(IVisaSpelet)));
        }

        [Test]
        public void RegelFabrik_borde_skapa_TagTidssteg()
        {
            var spelarhandlingMock = new Mock<ISpelarhandling>();
            var visaSpelet = new RegelFabrik { Spelvärld = new Spelvärld() }.SkapaTagTidssteg(spelarhandlingMock.Object);
            Assert.That(visaSpelet, Is.InstanceOf(typeof(ITagTidssteg)));
        }

        [Test]
        public void RegelFabrik_borde_göra_undantag_för_att_skapa_VisaSpelet_utan_spelvärld()
        {
            var ritareMock = new Mock<IRitare>();
            try
            {
                new RegelFabrik { Ritare = ritareMock.Object }.SkapaVisaSpelet();
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("visaspelet").And.Contain("spelvärld"));
            }
        }

        [Test]
        public void RegelFabrik_borde_göra_undantag_för_att_skapa_VisaSpelet_utan_ritare()
        {
            var ritareMock = new Mock<IRitare>();
            try
            {
                new RegelFabrik { Spelvärld = new Spelvärld() }.SkapaVisaSpelet();
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("visaspelet").And.Contain("ritare"));
            }
        }
    }
}
