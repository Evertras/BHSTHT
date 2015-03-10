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
    public class PlayerState : IPlayerState
    {
        public PlayerState(IBoardEntity hero,
                           IManaCrystalState manaCrystals,
                           IDeckState deck,
                           IHandState hand)
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
        public IManaCrystalState ManaCrystals { get; }

        /// <summary>
        /// The player's one and only hero
        /// </summary>
        public IBoardEntity Hero { get; }

        /// <summary>
        /// The player's current deck
        /// </summary>
        public IDeckState Deck { get; }

        /// <summary>
        /// The player's current hand
        /// </summary>
        public IHandState Hand { get; }

        /// <summary>
        /// Whether or not the player's hero is alive
        /// </summary>
        public bool IsAlive { get { return Hero.CurrentHealth > 0; } }

        /// <summary>
        /// Starts a new turn for the player
        /// </summary>
        public IPlayerState BeginTurn()
        {
            var playerState = Draw();

            return new PlayerState(
                playerState.Hero,
                playerState.ManaCrystals.BeginTurn(),
                playerState.Deck,
                playerState.Hand);
        }

        public IPlayerState AlterHero(HeroState hero)
        {
            return new PlayerState(hero, ManaCrystals, Deck, Hand);
        }

        public IPlayerState Draw()
        {
            try
            {
                ICard drawnCard;
                IDeckState newDeck = Deck.DrawRandom(out drawnCard);
                IHandState newHand = Hand.AddCard(drawnCard);

                return new PlayerState(
                    Hero,
                    ManaCrystals,
                    newDeck,
                    newHand);
            }
            catch (InvalidOperationException)
            {
                return new PlayerState(
                    Hero.Damage(1),
                    ManaCrystals,
                    Deck,
                    Hand);
            }
        }
    }
}
