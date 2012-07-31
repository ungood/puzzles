using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Primes
{
    public class TrialDivisionFactorer : IPrimeFactorer<long>
    {
        private readonly IPrimeGenerator<long> generator;

        public TrialDivisionFactorer(IPrimeGenerator<long> generator)
        {
            this.generator = generator;
        }

        public IEnumerable<long> Factor(long value)
        {
            var maxFactor = ((int)Math.Sqrt(value)) + 1;

            return generator.Generate()
                .TakeWhile(prime => prime < maxFactor)
                .Where(prime => value % prime == 0);
        }
    }
}
