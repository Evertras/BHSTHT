using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventActiveHeroRestoresMana : IGameEvent
    {
        public GameEventActiveHeroRestoresMana(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public IBoardState Apply(IBoardState initialState)
        {
            var alteredHero = initialState.ActivePlayerState.Hero.Heal(Amount);

            return initialState.AlterActivePlayer(initialState.ActivePlayerState.AlterHero(alteredHero));
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.LocalizeFormat("HeroHealed", boardState.ActivePlayerState.BattleTag, Amount);
        }
    }
}
