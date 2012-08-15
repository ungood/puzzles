using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Puzzles.Common
{
    public static class BigIntegerExtensions
    {
        public static long SumDigits(this BigInteger i, int radix)
        {
            long sum = 0;
            while(i > 0)
            {
                sum += (long)(i % radix);
                i /= radix;
            }

            return sum;
        }
    }
}
