using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class BildrutorBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<object, string> Strängrepresentationer => new Dictionary<object, string>
        {
            { new Bildrutor(new List<Bildruta>()), "[]" },
            { new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5))}), "[2@1 3,4,5]" },
            { new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))}), "[2@1 3,4,5;12@11 13,14,15]" }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            {
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))}),
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))})
            }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            {
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(9, 12, new Position(13, 14, 15))}),
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))})
            },
            {
                new Bildrutor(new List<Bildruta> {new Bildruta(9, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))}),
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))})
            },
            {
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5))}),
                new Bildrutor(new List<Bildruta> {new Bildruta(1, 2, new Position(3, 4, 5)), new Bildruta(11, 12, new Position(13, 14, 15))})
            }
        };

        [Test]
        public void Bildrutor_borde_ha_1_bildruta_när_de_skapas_med_1_bildruta()
        {
            var bildrutor = new Bildrutor(new List<Bildruta> { new Bildruta(1, 2, new Position(3, 4, 5)) });
            Assert.That(bildrutor.Antal, Is.EqualTo(1));
        }

        [Test]
        public void Bildrutor_borde_ha_2_bildruta_när_de_skapas_med_2_bildrutor()
        {
            var bildrutor = new Bildrutor(new List<Bildruta> {
                new Bildruta(1, 2, new Position(3, 4, 5)),
                new Bildruta(11, 12, new Position(13, 14, 15))
            });
            Assert.That(bildrutor.Antal, Is.EqualTo(2));
        }
    }
}
