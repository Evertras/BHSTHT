using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

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
                playerOne = playerOne.AlterHero(playerOne.Hero.Heal(Effect.Amount));

                updatedState = initialState.AlterPlayerOne(playerOne);
            }
            else if (Target == playerTwo.Hero)
            {
                playerTwo = playerTwo.AlterHero(playerTwo.Hero.Heal(Effect.Amount));

                updatedState = initialState.AlterPlayerTwo(playerTwo);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Couldn't find target");
            }

            return updatedState;
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return new GeneratedLocalizedString(string.Format(localizer.Localize("TargetHealDescription").Localized));
        }
    }
}
