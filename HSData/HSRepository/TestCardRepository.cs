using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSData;

namespace HSRepository
{
    /// <summary>
    /// A sample set of cards for testing purposes
    /// </summary>
    public class TestCardRepository : ICardRepository
    {
        private List<Card> cards = new List<Card>();

        public IReadOnlyList<Card> Cards
        {
            get
            {
                return cards;
            }
        }

        private Card GenerateDamageCard(int cost, int damage)
        {
            return new Card(cost, new List<CardEffect> { new CardEffectDamage(damage) });
        }

        private Card GenerateHealCard(int cost, int heal)
        {
            return new Card(cost, new List<CardEffect> { new CardEffectHeal(heal) });
        }

        /// <summary>
        /// Loads cards as specified in the test
        /// </summary>
        public void Load()
        {
            // a through e
            for (int i = 0; i < 5; ++i)
            {
                cards.Add(GenerateDamageCard(i, i));
            }

            // f
            cards.Add(GenerateHealCard(1, 1));

            // g
            cards.Add(new Card(1, new List<CardEffect> { new CardEffectDamage(1), new CardEffectDraw() }));
        }
    }
}
