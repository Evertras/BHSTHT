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
        public event Action<IBoard, EventArgs> StateChanged;

        private readonly List<BoardStateHistory> boardStates = new List<BoardStateHistory>();


        /// <summary>
        /// Creates an initial board state that can then be acted upon
        /// </summary>
        public Board(IPlayerState playerOneInitialState, IPlayerState playerTwoInitialState)
        {
            boardStates.Add(new BoardStateHistory(null,
                new BoardState(
                    playerOneInitialState?.BeginTurn().Draw().Draw().Draw(),
                    playerTwoInitialState?.Draw().Draw().Draw(),
                    BoardState.PlayerTurn.PlayerOne)));
        }

        /// <summary>
        /// Gets the current state of the board
        /// </summary>
        public IBoardState CurrentState
        {
            get
            {
                return boardStates.Last().BoardState;
            }
        }

        public IReadOnlyList<BoardStateHistory> History
        {
            get
            {
                return boardStates;
            }
        }


        /// <summary>
        /// Applies an event's effects and updates the current state
        /// </summary>
        /// <param name="gameEvent"></param>
        public void ApplyEvent(IGameEvent gameEvent)
        {
            boardStates.Add(new BoardStateHistory(gameEvent, gameEvent.Apply(CurrentState)));

            StateChanged?.Invoke(this, new EventArgs());
        }

        public void PlayCard(ICard card, IBoardEntity target = null)
        {
            var activeHand = CurrentState.ActivePlayerState.Hand;

            if (!activeHand.Cards.Contains(card))
            {
                throw new InvalidOperationException("Active player is not holding the card that's being played");
            }

            var updatedActivePlayerState = CurrentState.ActivePlayerState.AlterHand(activeHand.RemoveCard(card));

            boardStates.Add(new BoardStateHistory(new GameEventCardPlayed(card), CurrentState.AlterActivePlayer(updatedActivePlayerState)));

            foreach (var effect in card.Effects)
            {
                IGameEvent gameEvent;

                if (effect.RequiresTarget)
                {
                    gameEvent = effect.GenerateEvent(target);
                }
                else
                {
                    gameEvent = effect.GenerateEvent();
                }

                ApplyEvent(gameEvent);
            }
        }
    }
}
