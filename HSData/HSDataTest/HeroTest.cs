using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HSData;

namespace HSDataTest
{
    [TestClass]
    public class HeroTest
    {
        const int initialHP = 30;

        [TestMethod]
        public void HeroCanBeDamaged()
        {
            const int damageAmount = 5;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP);

            hero = hero.Damage(damageAmount);

            Assert.AreEqual(initialHP - damageAmount, hero.CurrentHealth);
        }

        [TestMethod]
        public void HeroCanBeDamagedBelowZero()
        {
            const int damageAmount = initialHP + 1;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP);

            hero = hero.Damage(damageAmount);

            Assert.AreEqual(initialHP - damageAmount, hero.CurrentHealth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HeroCannotBeDamagedForNegative()
        {
            const int negativeDamageAmount = -5;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP);

            hero = hero.Damage(negativeDamageAmount);

            Assert.Fail("Shouldn't have gotten here");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HeroCannotBeDamagedForZero()
        {
            const int zeroDamage = 0;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP);

            hero = hero.Damage(zeroDamage);

            Assert.Fail("Shouldn't have gotten here");
        }

        [TestMethod]
        public void HeroCanBeHealed()
        {
            const int healAmount = 5;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP - (healAmount + 1));

            hero = hero.Heal(healAmount);

            Assert.AreEqual(initialHP - 1, hero.CurrentHealth);
        }

        [TestMethod]
        public void HeroCantBeHealedPastMaxHealth()
        {
            const int healAmount = 5;
            IBoardEntity hero = new HeroState(initialHP, initialHP, initialHP - (healAmount - 1));

            hero = hero.Heal(healAmount);

            Assert.AreEqual(hero.MaxHealth, hero.CurrentHealth);
        }
    }
}
