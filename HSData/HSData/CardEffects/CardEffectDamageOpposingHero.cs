using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class CardEffectDamageOpposingHero : CardEffectUntargeted
    {
        public CardEffectDamageOpposingHero(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public override IGameEvent GenerateEvent()
        {
            return new GameEventDamageOpposingHero(this);
        }
    }
}
