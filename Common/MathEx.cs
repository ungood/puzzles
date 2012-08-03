using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common
{
    public static class MathEx
    {
        /// <summary>
        /// Returns the integer 2^x
        /// </summary>
        public static int Pow2(int value)
        {
            return (int)Math.Pow(2, value);
        }

        /// <summary>
        /// Returns the log, base 2, of a value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Lg2(int value)
        {
            return Math.Log(value, 2);
        }

        public static double ToDegrees(double radians)
        {
            return radians / (Math.PI / 180.0);
        }

        public static double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }

        #region LCM / GCD

        public static int Gcd(int a, int b)
        {
            if (b > a)
                return Gcd(b, a);

            return b == 0 ? a : Gcd(b, a % b);
        }

        public static int Lcm(int a, int b)
        {
            return a * b / Gcd(a, b);
        }

        public static long Gcd(long a, long b)
        {
            if (b > a)
                return Gcd(b, a);

            return b == 0 ? a : Gcd(b, a % b);
        }

        public static long Lcm(long a, long b)
        {
            return a * b / Gcd(a, b);
        }

        #endregion
    }
}
