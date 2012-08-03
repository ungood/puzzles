using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Primes
{
    public class TrialDivisionFactorer : IPrimeFactorer
    {
        private readonly IPrimeGenerator<long> generator;

        public TrialDivisionFactorer(IPrimeGenerator<long> generator)
        {
            this.generator = generator;
        }

        public PrimeFactorization Factor(long value)
        {
            return new PrimeFactorization(FactorImpl(value));
        } 

        private IEnumerable<long> FactorImpl(long value)
        {
            var maxFactor = ((int)Math.Sqrt(value)) + 1;

            using(var primes = generator.Generate().GetEnumerator())
            {
                primes.MoveNext();
                while(primes.Current < maxFactor)
                {
                    if (value % primes.Current == 0)
                    {
                        value /= primes.Current;
                        yield return primes.Current;
                    }
                    else
                    {
                        primes.MoveNext();
                    }
                }
            }
        }
    }
}
