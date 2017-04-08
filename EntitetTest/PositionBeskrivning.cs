using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    [TestFixture]
    public class PositionBeskrivning : EntitetsBeskrivning
    {
        protected override Dictionary<object, string> Strängrepresentationer => new Dictionary<object, string>
        {
            {new Position(1, 2, 3), "1,2,3" },
            {new Position(2, 3, 4), "2,3,4" }
        };

        protected override Dictionary<object, object> LikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Position(1, 2, 3), new Position(1, 2, 3) }
        };

        protected override Dictionary<object, object> InteLikvärdigaEntiteter => new Dictionary<object, object>
        {
            {new Position(9, 2, 3), new Position(1, 2, 3) },
            {new Position(1, 9, 3), new Position(1, 2, 3) },
            {new Position(1, 2, 9), new Position(1, 2, 3) }
        };
    }
}
