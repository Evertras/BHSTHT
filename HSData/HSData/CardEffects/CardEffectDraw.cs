using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class CardEffectDraw : CardEffectTargeted
    {
        public override IGameEvent GenerateEvent(IBoardEntity target)
        {
            return new GameEventDraw(target);
        }
    }
}
