using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventActivePlayerDraws : IGameEvent
    {
        public GameEventActivePlayerDraws()
        {
        }

        public IBoardState Apply(IBoardState initialState)
        {
            return initialState.AlterActivePlayer(initialState.ActivePlayerState.Draw());
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            string activeBattleTag = boardState.ActivePlayerState.BattleTag;

            return localizer.LocalizeFormat("DrawCard", activeBattleTag);
        }
    }
}
