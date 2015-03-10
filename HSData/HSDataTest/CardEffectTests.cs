using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class CardEffectTests
    {
        const int heroHealth = 30;

        [TestMethod]
        public void CanDamageHero()
        {
            const int damageToDeal = 5;

            BoardState board =
                new BoardState(
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth),
                        ManaCrystalState.StartingValue,
                        DeckState.EmptyDeck,
                        HandState.EmptyHand),
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth),
                        ManaCrystalState.StartingValue,
                        DeckState.EmptyDeck,
                        HandState.EmptyHand));

            CardEffect effect = new CardEffectDamage(damageToDeal);

            IBoardEntity target = board.PlayerTwo.Hero;

            var instance = effect.GenerateEvent(target);

            var alteredState = instance.Apply(board);

            Assert.AreEqual(heroHealth - damageToDeal, alteredState.PlayerTwo.Hero.CurrentHealth);
        }
    }
}
