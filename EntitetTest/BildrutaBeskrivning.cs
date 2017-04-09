using Entitet.Undantag;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class BildrutaBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<object, string> Strängrepresentationer => new Dictionary<object, string>
        {
            {new Bildruta(1, 2, new Position(3, 4, 5)), "2@1 3,4,5" },
            {new Bildruta(6, 17, new Position(1, 2, 3)), "17@6 1,2,3" }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(1, 2, new Position(3, 4, 5)) }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Bildruta(9, 2, new Position(3, 4, 5)), new Bildruta(1, 2, new Position(3, 4, 5)) },
            {new Bildruta(1, 9, new Position(3, 4, 5)), new Bildruta(1, 2, new Position(3, 4, 5)) },
            {new Bildruta(1, 2, new Position(9, 4, 5)), new Bildruta(1, 2, new Position(3, 4, 5)) }
        };

        [Test]
        public void Bildruta_borde_ha_egenskapen_visningstid()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Visningstid, Is.EqualTo(1));
        }

        [Test]
        public void Bildruta_borde_ha_egenskapen_bildindex()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Bildindex, Is.EqualTo(2));
        }

        [Test]
        public void Bildruta_borde_ha_egenskapen_position()
        {
            var bildruta = new Bildruta(1, 2, new Position(3, 4, 5));
            Assert.That(bildruta.Position, Is.EqualTo(new Position(3, 4, 5)));
        }

        [Test]
        public void Bildruta_borde_göra_undantag_från_att_skapas_utan_position()
        {
            try
            {
                new Bildruta(1, 2, null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("bildruta").And.Contain("position"));
            }
        }
    }
}
