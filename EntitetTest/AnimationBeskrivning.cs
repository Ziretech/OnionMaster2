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
    public class AnimationBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<object, string> Strängrepresentationer => new Dictionary<object, string>
        {
            {new Animation("a", new Bildrutor(new List<Bildruta>())), "a" },
            {new Animation("animationsid", new Bildrutor(new List<Bildruta>())), "animationsid" }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Animation("a", new Bildrutor(new List<Bildruta>())), new Animation("a", new Bildrutor(new List<Bildruta>())) },
            {new Animation("a", new Bildrutor(new List<Bildruta>{ new Bildruta(1, 2, new Position(3, 4, 5)) })), new Animation("a", new Bildrutor(new List<Bildruta>{new Bildruta(1, 2, new Position(3, 4, 5)) })) }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Animation("annanId", new Bildrutor(new List<Bildruta>{ new Bildruta(1, 2, new Position(3, 4, 5)) })), new Animation("a", new Bildrutor(new List<Bildruta>{new Bildruta(1, 2, new Position(3, 4, 5)) })) },
            {new Animation("a", new Bildrutor(new List<Bildruta>{ new Bildruta(9, 2, new Position(3, 4, 5)) })), new Animation("a", new Bildrutor(new List<Bildruta>{new Bildruta(1, 2, new Position(3, 4, 5)) })) }
        };

        [Test]
        public void Animation_borde_ha_en_id()
        {
            var animation = new Animation("animationsid", new Bildrutor(new List<Bildruta>()));
            Assert.That(animation.Id, Is.EqualTo("animationsid"));
        }

        [Test]
        public void Animation_borde_ha_bildrutor()
        {
            var bildrutor = new Bildrutor(new List<Bildruta>());
            var animation = new Animation("animationsid", bildrutor);
            Assert.That(animation.Bildrutor, Is.EqualTo(bildrutor));
        }

        [Test]
        public void Animation_borde_göra_undantag_för_att_skapas_utan_bildrutor()
        {
            try
            {
                new Animation("enId", null);
                Assert.Fail("Inget undantag gjordes.");
            }
            catch(UndantagFörSaknatKrav undantag)
            {
                Assert.That(undantag.Message.ToLower(), Does.Contain("animation").And.Contain("bildrutor"));
            }
        }
    }
}
