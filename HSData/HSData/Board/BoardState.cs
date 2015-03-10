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
    public class BoardState : IBoardState
    {
        public enum PlayerTurn
        {
            PlayerOne,
            PlayerTwo
        }

        /// <summary>
        /// The player one on the board.  Each player contains its own information of its deck, hero, minions, mana crystals, etc.
        /// </summary>
        public IPlayerState PlayerOne { get; }

        /// <summary>
        /// The player two on the board.  Each player contains its own information of its deck, hero, minions, mana crystals, etc.
        /// </summary>
        public IPlayerState PlayerTwo { get; }

        public PlayerTurn ActivePlayer { get; }

        /// <summary>
        /// Currently we only support a two player board, and each player must be unique
        /// </summary>
        public BoardState(IPlayerState playerOne, IPlayerState playerTwo, PlayerTurn activePlayer)
        {
            if (playerOne == null || playerTwo == null)
            {
                throw new ArgumentNullException("Player cannot be null");
            }

            if (playerOne == playerTwo)
            {
                throw new ArgumentException("Players cannot be set as a reference to each other");
            }

            PlayerOne = playerOne;
            PlayerTwo = playerTwo;

            ActivePlayer = activePlayer;
        }

        /// <summary>
        /// Adjusts player one, returning a new state representing the alteration
        /// </summary>
        /// <param name="alteredPlayerOne">The new state of player one</param>
        public IBoardState AlterPlayerOne(IPlayerState alteredPlayerOne)
        {
            return new BoardState(alteredPlayerOne, PlayerTwo, ActivePlayer);
        }

        /// <summary>
        /// Adjusts player two, returning a new state representing the alteration
        /// </summary>
        /// <param name="alteredPlayerTwo">The new state of player two</param>
        public IBoardState AlterPlayerTwo(IPlayerState alteredPlayerTwo)
        {
            return new BoardState(PlayerOne, alteredPlayerTwo, ActivePlayer);
        }

        /// <summary>
        /// Ends the current turn and begins the turn for the other player
        /// </summary>
        public IBoardState EndTurn()
        {
            if (ActivePlayer == PlayerTurn.PlayerOne)
            {
                return new BoardState(PlayerOne, PlayerTwo.BeginTurn(), PlayerTurn.PlayerTwo);
            }
            else
            {
                return new BoardState(PlayerOne.BeginTurn(), PlayerTwo, PlayerTurn.PlayerOne);
            }
        }
    }
}
