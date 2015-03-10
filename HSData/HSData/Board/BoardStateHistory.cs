using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public struct BoardStateHistory
    {
        internal BoardStateHistory(IGameEvent gameEvent, IBoardState boardState)
        {
            // Event can be null
            Event = gameEvent;

            // Board state cannot
            if (boardState == null)
            {
                throw new ArgumentNullException("Board state cannot be null");
            }

            BoardState = boardState;
        }

        public IGameEvent Event { get; }
        public IBoardState BoardState { get; }
    }
}
