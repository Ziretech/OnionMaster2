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
            var visaSpelet = new RegelFabrik().SkapaVisaSpelet(ritareMock.Object, new Spelvärld());
            Assert.That(visaSpelet, Is.InstanceOf(typeof(IVisaSpelet)));
        }
    }
}
