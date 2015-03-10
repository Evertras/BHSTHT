using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class GameEventTargetedHeal : GameEventTargeted, IGameEvent
    {
        public GameEventTargetedHeal(CardEffectHeal effect, IBoardEntity target) : base(target)
        {
            if (effect == null)
            {
                throw new ArgumentNullException("Effect cannot be null");
            }

            Effect = effect;
        }

        public CardEffectHeal Effect { get; }

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
                playerOne = new PlayerState(playerOne.Hero.Heal(Effect.Amount) as HeroState, playerOne.ManaCrystals, playerOne.Deck, playerOne.Hand);

                updatedState = new BoardState(playerOne, playerTwo);
            }
            else if (Target == playerTwo.Hero)
            {
                playerTwo = new PlayerState(playerTwo.Hero.Heal(Effect.Amount) as HeroState, playerTwo.ManaCrystals, playerTwo.Deck, playerTwo.Hand);

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
