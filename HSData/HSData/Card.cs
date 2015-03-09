using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    public class Card
    {
        public int Cost { get; }

        IReadOnlyList<CardEffect> Effects { get; }

        public Card(int cost, IReadOnlyList<CardEffect> effects)
        {
            Cost = cost;
            Effects = effects;
        }
    }
}
