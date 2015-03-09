using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class ManaCrystalTest
    {
        [TestMethod]
        public void BeginTurnIncrements()
        {
            const int expectedMax = 10;

            ManaCrystalState state = new ManaCrystalState(expectedMax - 1, expectedMax - 1);

            state = state.BeginTurn();

            Assert.AreEqual(expectedMax, state.Maximum);
        }

        [TestMethod]
        public void ManaCrystalsNeverGoPastMaxTen()
        {
            const int expectedMax = 10;

            ManaCrystalState state = new ManaCrystalState(expectedMax, expectedMax);

            state = state.BeginTurn();

            Assert.AreEqual(expectedMax, state.Maximum);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CannotHaveNegativeCurrent()
        {
            ManaCrystalState state = new ManaCrystalState(-1, 5);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CannotHaveNegativeMaximum()
        {
            ManaCrystalState state = new ManaCrystalState(1, -1);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CannotHaveCurrentHigherThanMax()
        {
            ManaCrystalState state = new ManaCrystalState(6, 5);
        }
    }
}
