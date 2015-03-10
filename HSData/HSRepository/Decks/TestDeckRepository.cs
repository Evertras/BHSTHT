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
        /// <summary>
        /// Loads a deck based on the test
        /// </summary>
        public IDeckState Load()
        {
            return DeckState.EmptyDeck;
        }
    }
}
