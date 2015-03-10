using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (initialState.ActivePlayer == BoardState.PlayerTurn.PlayerOne)
            {
                return initialState.AlterPlayerTwo(initialState.PlayerTwo.AlterHero(initialState.PlayerTwo.Hero.Damage(Effect.Amount)));
            }
            else
            {
                return initialState.AlterPlayerOne(initialState.PlayerOne.AlterHero(initialState.PlayerOne.Hero.Damage(Effect.Amount)));
            }
        }
    }
}
