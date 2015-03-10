using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// Represents a deck state
    /// </summary>
    public class DeckState : IDeckState
    {
        static private readonly Random rng = new Random();

        /// <summary>
        /// Represents an empty deck state
        /// </summary>
        public static readonly DeckState EmptyDeck = new DeckState(new List<Card>());

        public DeckState(IReadOnlyList<Card> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("Cards cannot be null");
            }

            Cards = cards;
        }

        /// <summary>
        /// The cards that are currently in the deck
        /// </summary>
        public IReadOnlyList<Card> Cards { get; }

        /// <summary>
        /// Adds a card to the deck
        /// </summary>
        /// <param name="card">The card to add</param>
        /// <returns>A new deck state including the added card</returns>
        public DeckState AddCard(Card card)
        {
            List<Card> newCards = new List<Card>(Cards);

            newCards.Add(card);

            return new DeckState(newCards);
        }

        /// <summary>
        /// Draws a card at random from the deck, returning an updated deck state with that card removed from it
        /// </summary>
        /// <param name="drawn">This variable will contain the card that was drawn</param>
        /// <returns>A new deck state excluding the drawn card</returns>
        public DeckState DrawRandom(out Card drawn)
        {
            if (!Cards.Any())
            {
                throw new InvalidOperationException("Cannot draw from an empty deck");
            }

            int randomIndex = rng.Next(0, Cards.Count);

            drawn = Cards[randomIndex];

            List<Card> newCards = new List<Card>(Cards);

            newCards.RemoveAt(randomIndex);

            return new DeckState(newCards);
        }
    }
}
