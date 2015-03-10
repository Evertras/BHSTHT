using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public abstract class CardEffectUntargeted : CardEffect
    {
        public override bool RequiresTarget { get { return false; } }

        public override IGameEvent GenerateEvent(IBoardEntity target)
        {
            throw new InvalidOperationException("This effect can't be targeted");
        }
    }
}
