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

        private Card GenerateDamageCard(int id, int cost, int damage)
        {
            return new Card(id, cost, new List<CardEffect> { new CardEffectDamage(damage) });
        }

        private Card GenerateHealCard(int id, int cost, int heal)
        {
            return new Card(id, cost, new List<CardEffect> { new CardEffectHeal(heal) });
        }

        /// <summary>
        /// Loads cards as specified in the test
        /// </summary>
        public void Load()
        {
            // a through e 1-5
            for (int i = 0; i < 5; ++i)
            {
                cards.Add(GenerateDamageCard(i + 1, i, i));
            }

            // f 6
            cards.Add(GenerateHealCard(6, 1, 1));

            // g 7
            cards.Add(new Card(7, 1, new List<CardEffect> { new CardEffectDamage(1), new CardEffectDraw() }));

            // TODO:
            // h 8 to be added
        }
    }
}
