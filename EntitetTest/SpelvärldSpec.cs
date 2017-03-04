using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class SpelvärldSpec
    {
        private Spelvärld _spelvärld;

        [SetUp]
        public void FöreTest()
        {
            _spelvärld = new Spelvärld();
        }

        [Test]
        public void Spelvärld_borde_innehålla_0_objekt_när_inget_har_lagts_till()
        {   
            Assert.That(_spelvärld.AntalObjekt(), Is.EqualTo(0));
        }

        [Test]
        public void Spelvärld_borde_innehålla_1_objekt_när_1_har_lagts_till()
        {
            _spelvärld.LäggTill(new Objekt());
            Assert.That(_spelvärld.AntalObjekt(), Is.EqualTo(1));
        }

        [Test]
        public void Spelvärld_borde_innehålla_2_objekt_när_2_har_lagts_till()
        {
            _spelvärld.LäggTill(new Objekt());
            _spelvärld.LäggTill(new Objekt());
            Assert.That(_spelvärld.AntalObjekt(), Is.EqualTo(2));
        }

        [Test]
        public void Spelvärld_borde_innehålla_10000_objekt_när_10000_har_lagts_till()
        {
            for(var i = 0; i < 10000; i++)
            {
                _spelvärld.LäggTill(new Objekt());
            }
            Assert.That(_spelvärld.AntalObjekt(), Is.EqualTo(10000));
        }
    }
}
