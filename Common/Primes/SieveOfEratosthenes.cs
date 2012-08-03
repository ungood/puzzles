using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Primes
{
    public class SieveOfEratosthenes : IPrimeGenerator<long>
    {
        public IEnumerable<long> Generate()
        {
            var primes = new List<long>();

            yield return 2;
            yield return 3;

            var value = 5L;
            var add4 = false;
            while(true)
            {
                if (!primes.Any(prime => value % prime == 0))
                {
                    primes.Add(value);
                    yield return value;
                }

                value += (add4 ? 4 : 2);
                add4 = !add4;
            }
        }
    }
}
