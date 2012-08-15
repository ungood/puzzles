using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Puzzles.Common.NumberTheory;

namespace Puzzles.Common.Sequences
{
    public class AmicableNumbers
    {
        private readonly IFactorer factorer;

        public AmicableNumbers(IFactorer factorer)
        {
            this.factorer = factorer;
        }

        public IEnumerable<Tuple<long, long>> Generate()
        {
            var n = 0L;
            while (n++ < long.MaxValue) 
            {
                var pair = FindAmicablePair(n);
                if(pair > 0)
                    yield return new Tuple<long, long>(n, pair);
            }
        } 

        private long FindAmicablePair(long n)
        {
            var divisors = factorer.FindNonTrivialFactors(n);
            var sum = divisors.Sum() + 1;
            if (sum == n)
                return -2;

            var divisorsOfSum = factorer.FindNonTrivialFactors(sum);

            return divisorsOfSum.Sum() + 1 == n ? sum : -1;
        }
    }
}
