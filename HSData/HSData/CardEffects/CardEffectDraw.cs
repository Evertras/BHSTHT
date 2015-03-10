using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class CardEffectActivePlayerDraws : CardEffectUntargeted
    {
        public override IGameEvent GenerateEvent()
        {
            return new GameEventActivePlayerDraws();
        }
    }
}
