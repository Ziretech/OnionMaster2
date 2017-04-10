using Entitet.Undantag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitet
{
    public class Animation
    {
        public string Id { get; }
        public Bildrutor Bildrutor { get; }

        public Animation(string id, Bildrutor bildrutor)
        {
            Id = id;
            Bildrutor = bildrutor ?? throw new UndantagFörSaknatKrav("Animation måste ha bildrutor.");
        }

        public override string ToString()
        {
            return Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Bildrutor.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var animation = (Animation)obj;
            return animation != null &&
                animation.Id.Equals(Id) &&
                animation.Bildrutor.Equals(Bildrutor);
        }
    }
}
