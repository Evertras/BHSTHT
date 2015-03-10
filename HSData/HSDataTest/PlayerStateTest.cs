using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class PlayerStateTest
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PlayerCantHaveNullBattleTag()
        {
            IPlayerState playerState = new PlayerState(null, new HeroState(4, 4, 4), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand);
        }

        [TestMethod]
        public void PlayerCanHaveNormalBattleTag()
        {
            IPlayerState playerState = new PlayerState("SomeBattletag", new HeroState(4, 4, 4), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void PlayerCantHaveWhitespaceBattleTag()
        {
            IPlayerState playerState = new PlayerState("  ", new HeroState(4, 4, 4), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand);
        }
        
        [TestMethod]
        public void BattleTagTrimmedCorrectly()
        {
            IPlayerState playerState = new PlayerState("  SomeBattletag", new HeroState(4, 4, 4), ManaCrystalState.StartingValue, DeckState.EmptyDeck, HandState.EmptyHand);

            Assert.AreEqual("SomeBattletag", playerState.BattleTag);
        }
    }
}
