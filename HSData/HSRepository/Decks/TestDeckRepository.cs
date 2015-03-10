using HSData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRepository
{
    public class TestDeckRepository : IDeckRepository
    {
        ICardRepository cardRepository;

        public TestDeckRepository(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }
        /// <summary>
        /// Loads a deck based on the test
        /// </summary>
        public IDeckState Load()
        {
            List<ICard> cards = new List<ICard>();

            for (int i = 0; i < 10; ++i)
            {
                cards.Add(cardRepository.GetByID(1));
            }

            for (int i = 0; i < 4; ++i)
            {
                cards.Add(cardRepository.GetByID(2));
            }

            cards.Add(cardRepository.GetByID(3));
            cards.Add(cardRepository.GetByID(3));

            cards.Add(cardRepository.GetByID(4));
            cards.Add(cardRepository.GetByID(4));

            cards.Add(cardRepository.GetByID(5));
            cards.Add(cardRepository.GetByID(5));

            for (int i = 0; i < 5; ++i)
            {
                cards.Add(cardRepository.GetByID(6));
            }

            cards.Add(cardRepository.GetByID(7));
            cards.Add(cardRepository.GetByID(7));

            return new DeckState(cards);
        }
    }
}
