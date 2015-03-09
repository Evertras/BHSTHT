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

        /// <summary>
        /// Creates an initial board state that can then be acted upon
        /// </summary>
        public Board(PlayerState playerOneInitialState, PlayerState playerTwoInitialState)
        {
            boardStates.Add(new BoardState(playerOneInitialState, playerTwoInitialState));
        }

        /// <summary>
        /// Gets the current state of the board
        /// </summary>
        public BoardState CurrentState
        {
            get
            {
                return boardStates.Last();
            }
        }
    }
}
