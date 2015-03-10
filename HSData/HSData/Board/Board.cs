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
    public class Board : IBoard
    {
        public struct BoardStateHistory
        {
            internal BoardStateHistory(IGameEvent gameEvent, BoardState boardState)
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
            public BoardState BoardState { get; }
        }

        private readonly List<BoardStateHistory> boardStates = new List<BoardStateHistory>();

        /// <summary>
        /// Creates an initial board state that can then be acted upon
        /// </summary>
        public Board(PlayerState playerOneInitialState, PlayerState playerTwoInitialState)
        {
            boardStates.Add(new BoardStateHistory(null, new BoardState(playerOneInitialState, playerTwoInitialState, BoardState.PlayerTurn.PlayerOne)));
        }

        /// <summary>
        /// Gets the current state of the board
        /// </summary>
        public BoardState CurrentState
        {
            get
            {
                return boardStates.Last().BoardState;
            }
        }

        /// <summary>
        /// Applies an event's effects and updates the current state
        /// </summary>
        /// <param name="gameEvent"></param>
        public void ApplyEvent(IGameEvent gameEvent)
        {
            boardStates.Add(new BoardStateHistory(gameEvent, gameEvent.Apply(CurrentState)));
        }
    }
}
