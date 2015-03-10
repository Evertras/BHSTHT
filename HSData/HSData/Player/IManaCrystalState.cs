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
        IManaCrystalState BeginTurn();

        /// <summary>
        /// Uses a given number of mana crystals
        /// </summary>
        /// <param name="amount">How many mana crystals to use</param>
        IManaCrystalState Use(int amount);

        /// <summary>
        /// Restores a given number of mana crystals, up to the maximum
        /// </summary>
        /// <param name="amount">How many mana crystals to restore</param>
        IManaCrystalState Restore(int amount);
    }
}