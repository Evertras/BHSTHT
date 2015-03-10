namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic immutable player state
    /// </summary>
    public interface IPlayerState
    {
        /// <summary>
        /// The player's deck
        /// </summary>
        DeckState Deck { get; }

        /// <summary>
        /// The player's hand
        /// </summary>
        HandState Hand { get; }

        /// <summary>
        /// The player's hero
        /// </summary>
        HeroState Hero { get; }

        /// <summary>
        /// The player's mana crystals
        /// </summary>
        ManaCrystalState ManaCrystals { get; }

        /// <summary>
        /// Alters the player's hero, returning a new player state representing the updated hero state
        /// </summary>
        /// <param name="hero">The hero state to update to</param>
        PlayerState AlterHero(HeroState hero);

        /// <summary>
        /// Begins the turn, applying all applicable events and returning the updated state
        /// </summary>
        PlayerState BeginTurn();

        /// <summary>
        /// Draws a card, returning the updated state
        /// </summary>
        PlayerState Draw();
    }
}