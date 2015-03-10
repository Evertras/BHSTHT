using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CanCreateBasicCard()
        {
            Card sampleCard = new Card(1, 1, Card.NoEffects);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CardCannotHaveNegativeCost()
        {
            Card badCard = new Card(1, -1, Card.NoEffects);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void CardCannotHaveNullEffectList()
        {
            Card badCard = new Card(1, 1, null);
        }
    }
}
