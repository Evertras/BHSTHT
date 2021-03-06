﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Math;

namespace HSData
{
    /// <summary>
    /// Contains immutable information about mana crystal state (available, max, locked, etc.)
    /// </summary>
    public class ManaCrystalState : IManaCrystalState
    {
        public static readonly ManaCrystalState StartingValue = new ManaCrystalState(0, 0);

        public ManaCrystalState(int current, int maximum)
        {
            if (current < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot have negative current mana crystals");
            }

            if (maximum < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot have negative maximum mana crystals");
            }

            if (current > maximum)
            {
                throw new ArgumentOutOfRangeException("Current mana crystals cannot be higher than maximum");
            }

            Maximum = maximum;
            Current = current;
        }

        public int Maximum { get; }
        public int Current { get; }

        public IManaCrystalState BeginTurn()
        {
            int newMax = Min(10, Maximum + 1);

            return new ManaCrystalState(newMax, newMax);
        }

        public IManaCrystalState Use(int amount)
        {
            if (amount > Current)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be greater than available crystals");
            }

            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException("Amount must be a positive integer");
            }

            return new ManaCrystalState(Current - amount, Maximum);
        }

        public IManaCrystalState Restore(int amount)
        {
            if (amount < 1)
            {
                throw new ArgumentOutOfRangeException("Amount must be a positive integer");
            }

            return new ManaCrystalState(Min(Current + amount, Maximum), Maximum);
        }
    }
}
