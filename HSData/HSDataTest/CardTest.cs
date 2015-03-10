using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;
using System.Collections.Generic;

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

        [TestMethod]
        public void CardDoesntRequireTargetWhenNoEffects()
        {
            Card someCard = new Card(1, 1, Card.NoEffects);

            Assert.IsFalse(someCard.RequiresTarget);
        }

        [TestMethod]
        public void CardRequiresTargetWhenOneEffectRequiresTarget()
        {
            Card someCard = new Card(1, 1, new List<ICardEffect> { new CardEffectDamage(4) });

            Assert.IsTrue(someCard.RequiresTarget);
        }

        public void CardCorrectlyGeneratesEventsWithMultipleDamageEffects()
        {
            Card someCard = new Card(1, 1, new List<ICardEffect> { new CardEffectDamage(4), new CardEffectDamage(2) });

            Assert.AreEqual(2, someCard.GenerateEvents(new HeroState(30, 30, 30)).Count);
        }
    }
}
