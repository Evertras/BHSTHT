using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public abstract class CardEffect : ICardEffect
    {
        public virtual bool RequiresTarget {  get { return false; } }

        public abstract IGameEvent GenerateEvent(IBoardEntity target);

        public abstract IGameEvent GenerateEvent();
    }
}
