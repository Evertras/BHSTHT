using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData
{
    /// <summary>
    /// IBoardEntity represents something on the playable board that has health and can have effects applied to it.
    /// </summary>
    /// <remarks>
    /// IBoardEntity objects are immutable.  Any alterations to them create and return copies of themselves in the modified state.
    /// </remarks>
    public interface IBoardEntity
    {
        /// <summary>
        /// The initial maximum health of the entity
        /// </summary>
        int InitialHealth { get; }

        /// <summary>
        /// The maximum health of the entity.
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        /// The current health of the entity, which may be less (or more)
        /// than the initial health depending on the entity's rules,
        /// but can never be higher than MaxHealth
        /// </summary>
        int CurrentHealth { get; }

        /// <summary>
        /// Damages the entity
        /// </summary>
        /// <param name="damageAmount">A positive integer</param>
        /// <returns></returns>
        IBoardEntity Damage(int damageAmount);

        /// <summary>
        /// Heals the entity, not exceeding its MaxHealth value
        /// </summary>
        /// <param name="healAmount"></param>
        /// <returns></returns>
        IBoardEntity Heal(int healAmount);
    }
}
