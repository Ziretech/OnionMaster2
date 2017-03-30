using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class BildBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<string, object> Strängrepresentationer => new Dictionary<string, object>
        {
            { "[1,2 3x4]", new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) },
            { "[2,3 4x5]", new Bild(new Bildmängdskoordinat(2, 3), new Bildstorlek(4, 5)) }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)), new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            { new Bild(new Bildmängdskoordinat(9, 2), new Bildstorlek(3, 4)), new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) },
            { new Bild(new Bildmängdskoordinat(1, 9), new Bildstorlek(3, 4)), new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) },
            { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(9, 4)), new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) },
            { new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 9)), new Bild(new Bildmängdskoordinat(1, 2), new Bildstorlek(3, 4)) }
        };
    }
}
