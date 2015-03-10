using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;
using HSRepository;
using System.Collections.Generic;
using System.Linq;

namespace HSDataTest
{
    [TestClass]
    public class BoardTest
    {
        const int initialHP = 30;

        [TestMethod]
        public void CanStartGame()
        {
            var board = new Board(
                new PlayerState("P1", new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
                new PlayerState("P2", new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerOne()
        {
            var board = new Board(
                null,
                new PlayerState("P2", new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerTwo()
        {
            var board = new Board(
                new PlayerState("P1", new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
                null);
        }

        [TestMethod]
        public void ManaCrystalMaximumsAdvanceProperlyEachTurn()
        {
            IDeckRepository testDeckRepository = new TestDeckRepository(new TestCardRepository());

            IDeckState playerOneDeck = testDeckRepository.Load();
            IDeckState playerTwoDeck = testDeckRepository.Load();

            var board =
                new Board(
                    new PlayerState(
                        "P1",
                        new HeroState(initialHP, initialHP, initialHP),
                        ManaCrystalState.StartingValue,
                        playerOneDeck,
                        HandState.EmptyHand),

                    new PlayerState(
                        "P2",
                        new HeroState(initialHP, initialHP, initialHP),
                        ManaCrystalState.StartingValue,
                        playerTwoDeck,
                        HandState.EmptyHand));

            Assert.AreEqual(BoardState.PlayerTurn.PlayerOne, board.CurrentState.ActivePlayer);
            Assert.AreEqual(1, board.CurrentState.PlayerOne.ManaCrystals.Maximum);
            Assert.AreEqual(0, board.CurrentState.PlayerTwo.ManaCrystals.Maximum);

            board.ApplyEvent(new GameEventTurnEnd());

            Assert.AreEqual(BoardState.PlayerTurn.PlayerTwo, board.CurrentState.ActivePlayer);
            Assert.AreEqual(1, board.CurrentState.PlayerOne.ManaCrystals.Maximum);
            Assert.AreEqual(1, board.CurrentState.PlayerTwo.ManaCrystals.Maximum);

            board.ApplyEvent(new GameEventTurnEnd());

            Assert.AreEqual(BoardState.PlayerTurn.PlayerOne, board.CurrentState.ActivePlayer);
            Assert.AreEqual(2, board.CurrentState.PlayerOne.ManaCrystals.Maximum);
            Assert.AreEqual(1, board.CurrentState.PlayerTwo.ManaCrystals.Maximum);
        }

        [TestMethod]
        public void CanPlaySimpleGame()
        {
            int i;
            ICard simpleDamageCard = new Card("Pewpew", 1, 1, new List<ICardEffect> { new CardEffectDamageOpposingHero(1) });
            List<ICard> repeatedCard = new List<ICard>();

            for (i = 0; i < initialHP + 10; ++i)
            {
                repeatedCard.Add(simpleDamageCard);
            }

            IDeckState simpleDeck = new DeckState(repeatedCard);

            IBoard board = new Board(
                new PlayerState(
                    "P1",
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    simpleDeck,
                    HandState.EmptyHand),
                new PlayerState(
                    "P2",
                    new HeroState(initialHP, initialHP, initialHP),
                    ManaCrystalState.StartingValue,
                    simpleDeck,
                    HandState.EmptyHand));

            const int infiniteGuard = 10000;

            for (i = 0; i < infiniteGuard && board.CurrentState.PlayerOne.IsAlive && board.CurrentState.PlayerTwo.IsAlive; ++i)
            {
                Assert.AreEqual(4, board.CurrentState.ActivePlayerState.Hand.Cards.Count);
                board.PlayCard(board.CurrentState.ActivePlayerState.Hand.Cards.First());
                Assert.AreEqual(3, board.CurrentState.ActivePlayerState.Hand.Cards.Count);

                board.ApplyEvent(new GameEventTurnEnd());
            }

            Assert.AreNotEqual(infiniteGuard, i);

            Assert.AreEqual(0, board.CurrentState.PlayerTwo.Hero.CurrentHealth);
            Assert.AreEqual(1, board.CurrentState.PlayerOne.Hero.CurrentHealth);
        }
    }
}
