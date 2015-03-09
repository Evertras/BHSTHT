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
            IBoardEntity hero = new Hero(initialHP, initialHP, initialHP);

            hero = hero.Damage(5);

            Assert.AreEqual(initialHP - 5, hero.CurrentHealth);
        }
    }
}
