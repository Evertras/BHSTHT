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
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP);

            hero = hero.Damage(damageAmount);

            Assert.AreEqual(initialHP - damageAmount, hero.CurrentHealth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HeroCannotBeDamagedForNegative()
        {
            const int negativeDamageAmount = -5;
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP);

            hero = hero.Damage(negativeDamageAmount);

            Assert.Fail("Shouldn't have gotten here");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HeroCannotBeDamagedForZero()
        {
            const int zeroDamage = 0;
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP);

            hero = hero.Damage(zeroDamage);

            Assert.Fail("Shouldn't have gotten here");
        }

        [TestMethod]
        public void HeroCanBeHealed()
        {
            const int healAmount = 5;
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP - healAmount);

            hero = hero.Heal(healAmount);

            Assert.AreEqual(initialHP, hero.CurrentHealth);
        }

        [TestMethod]
        public void HeroCantBeHealedPastMaxHealth()
        {
            const int healAmount = 5;
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP - (healAmount - 1));

            hero = hero.Heal(healAmount);

            Assert.AreEqual(initialHP, hero.CurrentHealth);
        }
    }
}
