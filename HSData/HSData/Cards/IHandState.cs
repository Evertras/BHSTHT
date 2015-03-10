using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic hand state
    /// </summary>
    public interface IHandState
    {
        /// <summary>
        /// The cards in the hand
        /// </summary>
        IReadOnlyList<Card> Cards { get; }

        /// <summary>
        /// Adds a card to the hand, returning a new state representing the new hand
        /// </summary>
        /// <param name="card">The card to add</param>
        HandState AddCard(Card card);

        /// <summary>
        /// Removes a card from the hand, returning a new state representing the new hand.
        /// If more than one of the specified card exists in the hand, only the first instance
        /// will be removed
        /// </summary>
        /// <param name="card">The card to remove</param>
        HandState RemoveCard(Card card);
    }
}