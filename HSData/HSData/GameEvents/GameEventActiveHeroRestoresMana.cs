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
            var alteredMana = initialState.ActivePlayerState.ManaCrystals.Restore(Amount);

            return initialState.AlterActivePlayer(initialState.ActivePlayerState.RestoreMana(Amount));
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.LocalizeFormat("HeroHealed", boardState.ActivePlayerState.BattleTag, Amount);
        }
    }
}
