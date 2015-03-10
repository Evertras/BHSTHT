using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic deck state
    /// </summary>
    public interface IDeckState
    {
        IReadOnlyList<ICard> Cards { get; }

        IDeckState AddCard(ICard card);

        IDeckState DrawRandom(out ICard drawn);
    }
}