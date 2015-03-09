using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// Represents a board and keeps track of all past actions, producing a single current immutable state
    /// </summary>
    public class Board
    {
        private readonly List<BoardState> boardStates = new List<BoardState>();
        public Board(PlayerState playerOneInitialState, PlayerState playerTwoInitialState)
        {
            boardStates.Add(new BoardState(playerOneInitialState, playerTwoInitialState));
        }

        public BoardState CurrentState
        {
            get
            {
                return boardStates.Last();
            }
        }
    }
}
