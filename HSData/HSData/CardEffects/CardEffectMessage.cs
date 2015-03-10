using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class CardEffectMessage : CardEffectUntargeted
    {
        public CardEffectMessage(string messageKey)
        {
            MessageKey = messageKey;
        }

        public string MessageKey { get; }

        public override IGameEvent GenerateEvent()
        {
            return new GameEventMessage(MessageKey);
        }
    }
}
