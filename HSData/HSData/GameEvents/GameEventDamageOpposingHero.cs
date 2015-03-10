using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventDamageOpposingHero : IGameEvent
    {
        public CardEffectDamageOpposingHero Effect { get; }

        public GameEventDamageOpposingHero(CardEffectDamageOpposingHero effect)
        {
            Effect = effect;
        }

        public IBoardState Apply(IBoardState initialState)
        {
            return initialState.AlterInactivePlayer(initialState.InactivePlayerState.AlterHero(initialState.InactivePlayerState.Hero.Damage(Effect.Amount)));
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.LocalizeFormat("HeroDamaged", boardState.InactivePlayerState.BattleTag);
        }
    }
}
