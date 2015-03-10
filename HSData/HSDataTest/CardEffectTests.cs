using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;
using System.Collections.Generic;

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

            BoardState boardState = 
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
                        HandState.EmptyHand),
                    BoardState.PlayerTurn.PlayerOne);

            CardEffect effect = new CardEffectDamage(damageToDeal);

            IBoardEntity target = boardState.PlayerTwo.Hero;

            var instance = effect.GenerateEvent(target);

            var alteredState = instance.Apply(boardState);

            Assert.AreEqual(heroHealth - damageToDeal, alteredState.PlayerTwo.Hero.CurrentHealth);
        }

        [TestMethod]
        public void CanHealHero()
        {
            const int damageToHeal = 5;

            BoardState board =
                new BoardState(
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth),
                        ManaCrystalState.StartingValue,
                        DeckState.EmptyDeck,
                        HandState.EmptyHand),
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth).Damage(damageToHeal) as HeroState,
                        ManaCrystalState.StartingValue,
                        DeckState.EmptyDeck,
                        HandState.EmptyHand),
                    BoardState.PlayerTurn.PlayerOne);

            CardEffect effect = new CardEffectHeal(damageToHeal);

            IBoardEntity target = board.PlayerTwo.Hero;

            var instance = effect.GenerateEvent(target);

            var alteredState = instance.Apply(board);

            Assert.AreEqual(heroHealth, alteredState.PlayerTwo.Hero.CurrentHealth);
        }

        [TestMethod]
        public void BothPlayersCanDrawCard()
        {
            Card someCard = new Card(1, 1, Card.NoEffects);

            DeckState simpleDeck = new DeckState(new List<Card> { someCard });

            IBoardState board =
                new BoardState(
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth),
                        ManaCrystalState.StartingValue,
                        simpleDeck,
                        HandState.EmptyHand),
                    new PlayerState(
                        new HeroState(heroHealth, heroHealth, heroHealth),
                        ManaCrystalState.StartingValue,
                        simpleDeck,
                        HandState.EmptyHand),
                    BoardState.PlayerTurn.PlayerOne
                    );

            CardEffect drawEffect = new CardEffectDraw();

            IBoardEntity target = board.PlayerOne.Hero;

            var instance = drawEffect.GenerateEvent(target);

            Assert.AreEqual(0, board.PlayerOne.Hand.Cards.Count);

            board = instance.Apply(board);

            Assert.AreEqual(1, board.PlayerOne.Hand.Cards.Count);

            Assert.AreEqual(0, board.PlayerTwo.Hand.Cards.Count);

            target = board.PlayerTwo.Hero;
            instance = drawEffect.GenerateEvent(target);
            board = instance.Apply(board);

            Assert.AreEqual(1, board.PlayerTwo.Hand.Cards.Count);
        }
    }
}
