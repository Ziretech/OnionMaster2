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
            var visaSpelet = new RegelFabrik(new Spelvärld(), ritareMock.Object).SkapaVisaSpelet();
            Assert.That(visaSpelet, Is.InstanceOf(typeof(IVisaSpelet)));
        }

        [Test]
        public void RegelFabrik_borde_göra_undantag_för_att_skapas_utan_spelvärld()
        {
            var ritareMock = new Mock<IRitare>();
            try
            {
                new RegelFabrik(null, ritareMock.Object);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärld"));
            }
        }

        [Test]
        public void RegelFabrik_borde_göra_undantag_för_att_skapas_utan_ritare()
        {
            try
            {
                new RegelFabrik(new Spelvärld(), null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch (UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("ritare"));
            }
        }
    }
}
