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
    public class HandState : IHandState
    {
        public static readonly HandState EmptyHand = new HandState(new List<ICard>());

        public HandState(IReadOnlyList<ICard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("Cards cannot be null");
            }

            Cards = cards;
        }
        public IReadOnlyList<ICard> Cards { get; }

        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card">The card to add</param>
        public IHandState AddCard(ICard card)
        {
            List<ICard> newCards = new List<ICard>(Cards);

            newCards.Add(card);

            return new HandState(newCards);
        }

        /// <summary>
        /// Removes a card from the hand
        /// </summary>
        /// <param name="card">The card to remove</param>
        public IHandState RemoveCard(ICard card)
        {
            List<ICard> newCards = new List<ICard>(Cards);

            newCards.Remove(card);

            return new HandState(newCards);
        }
    }
}
