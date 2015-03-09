using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;
using System.Collections.Generic;

namespace HSDataTest
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void CanAddCards()
        {
            var sampleEffects = new List<CardEffect>();
            var sampleCard = new Card(1, sampleEffects);
            var cards = new List<Card>();

            DeckState deck = DeckState.EmptyDeck;

            Assert.AreEqual(0, deck.Cards.Count);

            deck = deck.AddCard(sampleCard);
            deck = deck.AddCard(sampleCard);

            Assert.AreEqual(2, deck.Cards.Count);
        }

        [TestMethod]
        public void CanDrawCards()
        {
            var sampleEffects = new List<CardEffect>();
            var sampleCard = new Card(1, sampleEffects);
            var cards = new List<Card>();

            DeckState deck = DeckState.EmptyDeck;

            Assert.AreEqual(0, deck.Cards.Count);

            deck = deck.AddCard(sampleCard);
            deck = deck.AddCard(sampleCard);

            Assert.AreEqual(2, deck.Cards.Count);

            Card drawnCard;

            deck = deck.DrawRandom(out drawnCard);

            Assert.AreEqual(1, deck.Cards.Count);

            Assert.AreEqual(drawnCard, sampleCard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantDrawFromEmptyDeck()
        {
            DeckState deck = DeckState.EmptyDeck;
            Card drawnCard;

            Assert.AreEqual(0, deck.Cards.Count);

            deck = deck.DrawRandom(out drawnCard);
        }
    }
}
