using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class GameEventTurnEnd : IGameEvent
    {
        public IBoardState Apply(IBoardState initialState)
        {
            return initialState.EndTurn();
        }
    }
}
