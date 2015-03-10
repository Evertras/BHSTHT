using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void CanStartGame()
        {
            const int initialHP = 30;

            var board = new Board(
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerOne()
        {
            const int initialHP = 30;

            var board = new Board(
                null,
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantHaveNullPlayerTwo()
        {
            const int initialHP = 30;

            var board = new Board(
                new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand),
                null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CantHaveSamePlayerInstance()
        {
            const int initialHP = 30;

            var playerInstance = new PlayerState(new HeroState(initialHP, initialHP, initialHP), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand);

            var board = new Board(playerInstance, playerInstance);
        }
    }
}
