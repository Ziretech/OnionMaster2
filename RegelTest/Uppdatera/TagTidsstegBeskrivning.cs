using Entitet;
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
    public class TagTidsstegBeskrivning
    {
        [Test]
        public void TagTidssteg_borde_göra_undantag_för_att_skapas_utan_spelarhandling()
        {
            try
            {
                var tagTidssteg = new TagTidssteg(null, new Spelvärld());
                Assert.Fail();
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("spelarhandling"));
            }
        }

        [Test]
        public void TagTidssteg_borde()
        {
            var spelarhandlingStub = new Mock<ISpelarhandling>();
            var spelvärld = new Spelvärld();
            var tagTidssteg = new TagTidssteg(spelarhandlingStub.Object, spelvärld);
        }
    }
}
