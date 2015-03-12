using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventHealActiveHero : IGameEvent
    {
        public int Amount { get; }

        public GameEventHealActiveHero(int amount)
        {
            Amount = amount;
        }

        public IBoardState Apply(IBoardState initialState)
        {
            return initialState.AlterActivePlayer(initialState.ActivePlayerState.AlterHero(initialState.ActivePlayerState.Hero.Heal(Amount)));
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.LocalizeFormat("HeroHealed", boardState.ActivePlayerState.BattleTag, Amount);
        }
    }
}
