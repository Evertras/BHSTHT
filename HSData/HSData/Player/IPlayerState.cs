namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic immutable player state
    /// </summary>
    public interface IPlayerState
    {
        /// <summary>
        /// A raw string indicating the player's battle tag
        /// </summary>
        string BattleTag { get; }

        /// <summary>
        /// The player's deck
        /// </summary>
        IDeckState Deck { get; }

        /// <summary>
        /// The player's hand
        /// </summary>
        IHandState Hand { get; }

        /// <summary>
        /// The player's hero
        /// </summary>
        IBoardEntity Hero { get; }

        /// <summary>
        /// Returns true if the player's hero is still alive
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// The player's mana crystals
        /// </summary>
        IManaCrystalState ManaCrystals { get; }

        /// <summary>
        /// Alters the player's hero, returning a new player state representing the updated hero state
        /// </summary>
        /// <param name="hero">The hero state to update to</param>
        IPlayerState AlterHero(IBoardEntity hero);

        /// <summary>
        /// Begins the turn, applying all applicable events and returning the updated state
        /// </summary>
        IPlayerState BeginTurn();

        /// <summary>
        /// Draws a card, returning the updated state
        /// </summary>
        IPlayerState Draw();
    }
}