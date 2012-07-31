using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Extensions
{
    public static class PowerExtensions
    {
        /// <summary>
        /// Returns the integer 2^x
        /// </summary>
        public static int Pow2(this int value)
        {
            return (int)System.Math.Pow(2, value);
        }

        public static double Lg2(this int value)
        {
            return Math.Log(value, 2);
        }
    }
}
