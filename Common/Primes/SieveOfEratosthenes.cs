using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Primes
{
    public class SieveOfEratosthenes : IPrimeGenerator<long>
    {
        public IEnumerable<long> Generate()
        {
            var primes = new List<long>(new long[] {2, 3});

            yield return 2;
            yield return 3;

            var value = 3L;
            while((value += 2) < long.MaxValue)
            {
                if (primes.Any(prime => value % prime == 0))
                    continue;

                primes.Add(value);
                yield return value;
            }
        }
    }
}
