using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic deck state
    /// </summary>
    public interface IDeckState
    {
        IReadOnlyList<Card> Cards { get; }

        DeckState AddCard(Card card);
        DeckState DrawRandom(out Card drawn);
    }
}