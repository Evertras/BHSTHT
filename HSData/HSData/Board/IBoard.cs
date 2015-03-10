using System;
using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic board that manages state changes
    /// </summary>
    public interface IBoard
    {
        IBoardState CurrentState { get; }

        IReadOnlyList<BoardStateHistory> History { get; }

        void ApplyEvent(IGameEvent gameEvent);

        /// <summary>
        /// The active player plays the given card if it's in their hand
        /// </summary>
        /// <param name="card">The card from the player's hand to play</param>
        /// <param name="target">The target, if required</param>
        void PlayCard(ICard card, IBoardEntity target = null);

        event Action<IBoard, EventArgs> StateChanged;
    }
}