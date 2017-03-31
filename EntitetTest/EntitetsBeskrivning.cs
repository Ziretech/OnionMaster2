using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public abstract class EntitetsBeskrivning
    {
        protected abstract Dictionary<object, string> Strängrepresentationer { get; }

        protected abstract Dictionary<object, object> LikvärdigaEntiteter { get; }

        protected abstract Dictionary<object, object> InteLikvärdigaEntiteter { get; }

        [Test]
        public void Entiteter_borde_ha_en_strängrepresentation()
        {
            foreach(var testfall in Strängrepresentationer)
            {
                Assert.That(testfall.Key.ToString(), Is.EqualTo(testfall.Value), "Felaktig strängrepresentation för " + testfall.Key.GetType().ToString());
            }
        }

        [Test]
        public void Entiteter_borde_vara_likvärdiga_likvärdiga_entiteter()
        {
            foreach(var testfall in LikvärdigaEntiteter)
            {
                Assert.That(testfall.Value, Is.EqualTo(testfall.Key), "Inte likvärdiga entiteter av typ " + testfall.Key.GetType().ToString());
            }
        }

        [Test]
        public void Entiteter_borde_inte_vara_likvärdiga_icke_likvärdiga_entiteter()
        {
            foreach (var testfall in InteLikvärdigaEntiteter)
            {
                Assert.That(testfall.Value, Is.Not.EqualTo(testfall.Key), "Likvärdiga entiteter av typ " + testfall.Key.GetType().ToString());
            }
        }

        [Test]
        public void Entiteter_borde_ha_samma_hashcode_som_likvärdiga_entiteter()
        {
            foreach (var testfall in LikvärdigaEntiteter)
            {
                Assert.That(testfall.Value.GetHashCode(), Is.EqualTo(testfall.Key.GetHashCode()), "Inte samma hashcode för likvärdiga entiteter av typ " + testfall.Key.GetType().ToString());
            }
        }

        [Test]
        public void Entiteter_borde_inte_ha_samma_hashcode_som_icke_likvärdiga_entiteter()
        {
            foreach (var testfall in InteLikvärdigaEntiteter)
            {
                Assert.That(testfall.Value.GetHashCode(), Is.Not.EqualTo(testfall.Key.GetHashCode()), "Samma hashcode för icke likvärdiga entiteter av typ " + testfall.Key.GetType().ToString());
            }
        }
    }
}
