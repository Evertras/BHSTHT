using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// Represents a card and all relevant information about that card, barring any modifiers
    /// </summary>
    public class Card
    {
        public static readonly IReadOnlyList<CardEffect> NoEffects = new List<CardEffect>();

        public int Cost { get; }

        IReadOnlyList<CardEffect> Effects { get; }

        public Card(int cost, IReadOnlyList<CardEffect> effects)
        {
            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException("Cost cannot be less than zero");
            }

            if (effects == null)
            {
                throw new ArgumentNullException("Effects cannot be null");
            }

            Cost = cost;
            Effects = effects;
        }
    }
}
