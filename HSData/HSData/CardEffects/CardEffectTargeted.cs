using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public abstract class CardEffectTargeted : CardEffect
    {
        public override bool RequiresTarget { get { return true; } }

        public override IGameEvent GenerateEvent()
        {
            throw new NotImplementedException("This effect requires a target");
        }
    }
}
