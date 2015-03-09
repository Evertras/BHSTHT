using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// Represent's a player's immutable hand state
    /// </summary>
    public class HandState
    {
        public static readonly HandState EmptyHand = new HandState(new List<Card>());

        public HandState(IReadOnlyList<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("Cards cannot be null");
            }

            Cards = cards;
        }
        public IReadOnlyList<Card> Cards { get; }

        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card">The card to add</param>
        public HandState AddCard(Card card)
        {
            List<Card> newCards = new List<Card>(Cards);

            newCards.Add(card);

            return new HandState(newCards);
        }

        /// <summary>
        /// Removes a card from the hand
        /// </summary>
        /// <param name="card">The card to remove</param>
        public HandState RemoveCard(Card card)
        {
            List<Card> newCards = new List<Card>(Cards);

            newCards.Remove(card);

            return new HandState(newCards);
        }
    }
}
