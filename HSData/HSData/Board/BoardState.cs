using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// Represents a single immutable board state
    /// </summary>
    public class BoardState
    {
        /// <summary>
        /// The players on the board.  Each player contains its own information of its deck, hero, minions, mana crystals, etc.
        /// </summary>
        public IReadOnlyList<PlayerState> Players { get; }

        /// <summary>
        /// Currently we only support a two player board, and each player must be unique
        /// </summary>
        public BoardState(PlayerState playerOne, PlayerState playerTwo)
        {
            if (playerOne == null || playerTwo == null)
            {
                throw new ArgumentNullException("Player cannot be null");
            }

            if (playerOne == playerTwo)
            {
                throw new ArgumentException("Players cannot be set as a reference to each other");
            }

            Players = new List<PlayerState>
            {
                playerOne,
                playerTwo
            };
        }
    }
}
