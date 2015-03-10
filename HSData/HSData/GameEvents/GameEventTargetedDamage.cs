using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class GameEventTargetedDamage : GameEventTargeted, IGameEvent
    {
        public GameEventTargetedDamage(CardEffectDamage damageEffect, IBoardEntity target) : base(target)
        {
            if (damageEffect == null)
            {
                throw new ArgumentNullException("Damage effect cannot be null");
            }

            Effect = damageEffect;
        }

        CardEffectDamage Effect { get; }

        public IBoardState Apply(IBoardState initialState)
        {
            if (initialState == null)
            {
                throw new ArgumentNullException("Board cannot be null");
            }

            var updatedState = initialState;
            var playerOne = updatedState.PlayerOne;
            var playerTwo = updatedState.PlayerTwo;

            if (Target == playerOne.Hero)
            {
                playerOne = playerOne.AlterHero(playerOne.Hero.Damage(Effect.Amount) as HeroState);

                updatedState = initialState.AlterPlayerOne(playerOne);
            }
            else if (Target == playerTwo.Hero)
            {
                playerTwo = playerTwo.AlterHero(playerTwo.Hero.Damage(Effect.Amount) as HeroState);

                updatedState = initialState.AlterPlayerTwo(playerTwo);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Couldn't find target");
            }

            return updatedState;
        }
    }
}
