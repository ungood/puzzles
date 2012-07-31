using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problem5
{
    public class Puzzle
    {
        private IPrimeFactorer<long> factorer;

        public Puzzle()
        {
            var primeGenerator = new SieveOfEratosthenes();
            factorer = new TrialDivisionFactorer(primeGenerator);
        }

        private long Solve(int max)
        {
            Enumerable.Range(1, max).Select()

            
        }

        private IEnumerable<Tuple<long, long>> Factor(long value)
        {
            return factorer.Factor(value)
                .Select(prime => new Tuple<long, long>(prime, value / prime));
        }
    }
}
