using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;
using HSRepository;

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
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerOne()
        {
            var board = new Board(
                null,
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerTwo()
        {
            var board = new Board(
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
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
                        new HeroState(initialHP, initialHP, initialHP),
                        ManaCrystalState.StartingValue,
                        playerOneDeck,
                        HandState.EmptyHand),

                    new PlayerState(
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
    }
}
