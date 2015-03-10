using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventCardPlayed : IGameEvent
    {
        public GameEventCardPlayed(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("Card cannot be null");
            }

            Card = card;
        }

        public ICard Card { get; }

        public IBoardState Apply(IBoardState initialState)
        {
            return initialState;
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.LocalizeFormat("CardPlayed", boardState.ActivePlayerState.BattleTag, localizer.Localize(Card.NameKey));
        }
    }
}
