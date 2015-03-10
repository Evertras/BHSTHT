namespace HSData
{
    /// <summary>
    /// Interface for a generic mana crystal state
    /// </summary>
    public interface IManaCrystalState
    {
        /// <summary>
        /// The current mana crystals available
        /// </summary>
        int Current { get; }

        /// <summary>
        /// The maximum number of mana crystals available
        /// </summary>
        int Maximum { get; }

        /// <summary>
        /// Begins the turn, returning a new state representing the mana crystals available to the player at the beginning of the turn
        /// </summary>
        ManaCrystalState BeginTurn();
    }
}