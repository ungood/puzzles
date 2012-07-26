using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Extensions
{
    public static class PowerExtensions
    {
        public static int Pow2(this int value)
        {
            return (int)System.Math.Pow(2, value);
        }
    }
}
