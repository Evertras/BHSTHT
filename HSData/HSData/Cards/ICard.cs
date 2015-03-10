using System.Collections.Generic;

namespace HSData
{
    /// <summary>
    /// Defines an interface for a generic card
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// The internal ID of the card
        /// </summary>
        int ID { get; }

        /// <summary>
        /// The name key that will be used by ILocalizer to retrieve the name of the card
        /// </summary>
        string NameKey { get; }

        /// <summary>
        /// The cost of the card
        /// </summary>
        int Cost { get; }

        /// <summary>
        /// The effects of the card when it's played
        /// </summary>
        IReadOnlyList<ICardEffect> Effects { get; }

        /// <summary>
        /// Whether or not the card requires a target
        /// </summary>
        bool RequiresTarget { get; }

        /// <summary>
        /// Generates all applicable events from the card given a target, if required
        /// </summary>
        /// <param name="target">The target, if required</param>
        IReadOnlyList<IGameEvent> GenerateEvents(IBoardEntity target = null);
    }
}