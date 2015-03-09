using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// A single immutable player state
    /// </summary>
    public class PlayerState
    {
        public PlayerState(HeroState hero, ManaCrystalState manaCrystals)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null");
            }

            if (manaCrystals == null)
            {
                throw new ArgumentNullException("Mana crystal state cannot be null");
            }

            Hero = hero;
            ManaCrystals = manaCrystals;
        }

        /// <summary>
        /// The mana crystals of the player
        /// </summary>
        public ManaCrystalState ManaCrystals { get; }

        /// <summary>
        /// The player's one and only hero
        /// </summary>
        public HeroState Hero { get; }

        /// <summary>
        /// Starts a new turn for the player
        /// </summary>
        public PlayerState BeginTurn()
        {
            return new PlayerState(Hero, ManaCrystals.BeginTurn());
        }
    }
}
