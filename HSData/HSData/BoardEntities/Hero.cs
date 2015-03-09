using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace HSData
{
    /// <summary>
    /// A hero that belongs to the player
    /// </summary>
    public class Hero : IBoardEntity
    {
        public Hero(int initialHealth, int maxHealth, int currentHealth)
        {
            InitialHealth = initialHealth;
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }

        public int CurrentHealth { get; }

        public int InitialHealth { get; }

        public int MaxHealth { get; }

        public IBoardEntity Damage(int damageAmount)
        {
            if (damageAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Damage must be a positive integer greater than zero");
            }

            return new Hero(InitialHealth, MaxHealth, CurrentHealth - damageAmount);
        }

        public IBoardEntity Heal(int healAmount)
        {
            if (healAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Healing must be a positive integer greater than zero");
            }

            return new Hero(InitialHealth, MaxHealth, Min(MaxHealth, CurrentHealth + healAmount));
        }
    }
}
