﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class CardEffectHeal : CardEffectTargeted
    {
        public CardEffectHeal(int amount)
        {
            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException("Damage cannot be less than zero");
            }

            Amount = amount;
        }

        /// <summary>
        /// How much to damage the target by
        /// </summary>
        public int Amount { get; }

        public override IGameEvent GenerateEvent(IBoardEntity target)
        {
            return new GameEventTargetedHeal(this, target);
        }
    }
}
