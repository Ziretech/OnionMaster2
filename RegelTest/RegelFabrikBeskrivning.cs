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
            var visaSpelet = new RegelFabrik(new Spelvärld()).SkapaVisaSpelet(ritareMock.Object);
            Assert.That(visaSpelet, Is.InstanceOf(typeof(IVisaSpelet)));
        }

        [Test]
        public void RegelFabrik_borde_göra_undantag_för_att_skapas_utan_spelvärld()
        {
            try
            {
                new RegelFabrik(null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelvärld"));
            }
        }
    }
}
