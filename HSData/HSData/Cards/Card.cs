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
    public class Card : ICard
    {
        public static readonly IReadOnlyList<ICardEffect> NoEffects = new List<ICardEffect>();

        public int ID { get; }

        public int Cost { get; }

        public IReadOnlyList<ICardEffect> Effects { get; }

        public bool RequiresTarget
        {
            get
            {
                return Effects.Any(e => e.RequiresTarget);
            }
        }

        public Card(int id, int cost, IReadOnlyList<ICardEffect> effects)
        {
            if (cost < 0)
            {
                throw new ArgumentOutOfRangeException("Cost cannot be less than zero");
            }

            if (effects == null)
            {
                throw new ArgumentNullException("Effects cannot be null");
            }

            // ID can be anything, for the moment

            ID = id;
            Cost = cost;
            Effects = effects;
        }

        public IReadOnlyList<IGameEvent> GenerateEvents(IBoardEntity target = null)
        {
            List<IGameEvent> events = new List<IGameEvent>();

            foreach (var effect in Effects)
            {
                if (effect.RequiresTarget)
                {
                    events.Add(effect.GenerateEvent(target));
                }
                else
                {
                    events.Add(effect.GenerateEvent());
                }
            }

            return events;
        }
    }
}
