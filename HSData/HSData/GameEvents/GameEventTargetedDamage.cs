using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class GameEventTargetedDamage : IGameEvent
    {
        public GameEventTargetedDamage(CardEffectDamage damageEffect, IBoardEntity target)
        {
            if (target == null)
            {
                throw new ArgumentNullException("Target cannot be null");
            }

            Target = target;
            Effect = damageEffect;
        }

        IBoardEntity Target { get; }

        CardEffectDamage Effect { get; }

        public BoardState Apply(BoardState initialState)
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
                playerOne = new PlayerState(playerOne.Hero.Damage(Effect.Amount) as HeroState, playerOne.ManaCrystals, playerOne.Deck, playerOne.Hand);

                updatedState = new BoardState(playerOne, playerTwo);
            }
            else if (Target == playerTwo.Hero)
            {
                playerTwo = new PlayerState(playerTwo.Hero.Damage(Effect.Amount) as HeroState, playerTwo.ManaCrystals, playerTwo.Deck, playerTwo.Hand);

                updatedState = new BoardState(playerOne, playerTwo);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Couldn't find target");
            }

            return updatedState;
        }
    }
}
