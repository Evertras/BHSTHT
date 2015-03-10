using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSData;

namespace HSRepository
{
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

        public void Load()
        {
            for (int i = 0; i < 5; ++i)
            {
                cards.Add(GenerateDamageCard(i, i));
            }

            cards.Add(GenerateHealCard(1, 1));
        }
    }
}
