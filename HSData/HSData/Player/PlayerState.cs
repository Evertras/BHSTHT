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
        public PlayerState(string battleTag,
                           IBoardEntity hero,
                           IManaCrystalState manaCrystals,
                           IDeckState deck,
                           IHandState hand)
        {
            if (string.IsNullOrEmpty(battleTag?.Trim()))
            {
                throw new ArgumentNullException("Battle tag cannot be empty");
            }

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
            BattleTag = battleTag.Trim();
        }

        /// <summary>
        /// The battle tag of the player
        /// </summary>
        public string BattleTag { get; }

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
                playerState.BattleTag,
                playerState.Hero,
                playerState.ManaCrystals.BeginTurn(),
                playerState.Deck,
                playerState.Hand);
        }

        public IPlayerState AlterHero(IBoardEntity hero)
        {
            return new PlayerState(BattleTag, hero, ManaCrystals, Deck, Hand);
        }

        public IPlayerState Draw()
        {
            try
            {
                ICard drawnCard;
                IDeckState newDeck = Deck.DrawRandom(out drawnCard);
                IHandState newHand = Hand.AddCard(drawnCard);

                return new PlayerState(
                    BattleTag,
                    Hero,
                    ManaCrystals,
                    newDeck,
                    newHand);
            }
            catch (InvalidOperationException)
            {
                return AlterHero(Hero.Damage(1));
            }
        }

        public IPlayerState AlterHand(IHandState hand)
        {
            return new PlayerState(BattleTag, Hero, ManaCrystals, Deck, hand);
        }

        public IPlayerState UseMana(int amount)
        {
            return new PlayerState(BattleTag, Hero, ManaCrystals.Use(amount), Deck, Hand);
        }

        public IPlayerState RestoreMana(int amount)
        {
            return new PlayerState(BattleTag, Hero, ManaCrystals.Restore(amount), Deck, Hand);
        }
    }
}
