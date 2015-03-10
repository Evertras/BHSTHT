using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic card
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// The cost of the card
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// The effects of the card when it's played
        /// </summary>
        IReadOnlyList<ICardEffect> Effects { get; }
    }
}