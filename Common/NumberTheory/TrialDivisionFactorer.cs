using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.NumberTheory
{
    public class TrialDivisionFactorer : IFactorer
    {
        public IEnumerable<long> FindNonTrivialFactors(long n)
        {
            if (n < 4)
                yield break;

            var maxFactor = (long)(Math.Sqrt(n) + 1);
            for(long i = 2; i <= maxFactor; i++)
            {
                long remainder;
                var quotient = Math.DivRem(n, i, out remainder);
                if(remainder == 0)
                {
                    yield return i;
                    if(quotient > maxFactor)
                        yield return quotient;
                }
            }
        }
    }
}
