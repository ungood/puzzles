using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Primes
{
    public class TrialDivisionFactorer : IPrimeFactorer
    {
        private readonly IPrimeGenerator generator;

        public TrialDivisionFactorer(IPrimeGenerator generator)
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
                while(primes.Current < maxFactor && primes.Current <= value)
                {
                    long rem;
                    var div = Math.DivRem(value, primes.Current, out rem);
                    if (rem == 0)
                    {
                        value = div;
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
