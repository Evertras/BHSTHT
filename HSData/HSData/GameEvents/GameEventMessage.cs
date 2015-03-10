using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;

namespace HSData
{
    public class GameEventMessage : IGameEvent
    {
        public GameEventMessage(string messageKey)
        {
            MessageKey = messageKey;
        }

        public string MessageKey { get; }

        public IBoardState Apply(IBoardState initialState)
        {
            // No actual change
            return initialState;
        }

        public LocalizedString Describe(IBoardState boardState, ILocalizer localizer)
        {
            return localizer.Localize(MessageKey);
        }
    }
}
