using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace HSData
{
    /// <summary>
    /// A single immutable hero state that belongs to a player
    /// </summary>
    public class HeroState : IBoardEntity
    {
        public HeroState(int initialHealth, int maxHealth, int currentHealth)
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

            return new HeroState(InitialHealth, MaxHealth, CurrentHealth - damageAmount);
        }

        public IBoardEntity Heal(int healAmount)
        {
            if (healAmount <= 0)
            {
                throw new ArgumentOutOfRangeException("Healing must be a positive integer greater than zero");
            }

            return new HeroState(InitialHealth, MaxHealth, Min(MaxHealth, CurrentHealth + healAmount));
        }
    }
}
