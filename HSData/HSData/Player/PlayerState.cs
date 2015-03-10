using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// A single immutable player state
    /// </summary>
    public class PlayerState
    {
        public PlayerState(HeroState hero,
                           ManaCrystalState manaCrystals,
                           DeckState deck,
                           HandState hand)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null");
            }

            if (manaCrystals == null)
            {
                throw new ArgumentNullException("Mana crystal state cannot be null");
            }

            if (deck == null)
            {
                throw new ArgumentNullException("Deck cannot be null");
            }

            if (hand == null)
            {
                throw new ArgumentNullException("Hand cannot be null");
            }

            Hero = hero;
            ManaCrystals = manaCrystals;
            Deck = deck;
            Hand = hand;
        }

        /// <summary>
        /// The mana crystals of the player
        /// </summary>
        public ManaCrystalState ManaCrystals { get; }

        /// <summary>
        /// The player's one and only hero
        /// </summary>
        public HeroState Hero { get; }

        /// <summary>
        /// The player's current deck
        /// </summary>
        public DeckState Deck { get; }

        /// <summary>
        /// The player's current hand
        /// </summary>
        public HandState Hand { get; }

        /// <summary>
        /// Starts a new turn for the player
        /// </summary>
        public PlayerState BeginTurn()
        {
            Card drawnCard;
            DeckState newDeck = Deck.DrawRandom(out drawnCard);
            HandState newHand = Hand.AddCard(drawnCard);

            return new PlayerState(
                hero: Hero,
                manaCrystals: ManaCrystals.BeginTurn(),
                deck: newDeck,
                hand: newHand);
        }

        public PlayerState AlterHero(HeroState hero)
        {
            return new PlayerState(hero, ManaCrystals, Deck, Hand);
        }
    }
}
