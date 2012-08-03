using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Primes
{
    public struct PrimeFactor
    {
        public long Prime { get; private set; }
        public int Coefficient { get; private set; }

        public PrimeFactor(long prime, int coefficient) : this()
        {
            Coefficient = coefficient;
            Prime = prime;
        }
    }

    public class PrimeFactorization
    {
        private readonly IList<PrimeFactor> primeFactors;

        public PrimeFactorization(IEnumerable<long> primes)
        {
            primeFactors = primes.GroupBy(x => x).Select(g => new PrimeFactor(g.Key, g.Count())).ToList();
        }

        public IEnumerable<long> Primes
        {
            get { return primeFactors.Select(p => p.Prime); }
        } 

        public IEnumerable<int> Coefficients
        {
            get { return primeFactors.Select(p => p.Coefficient); }
        }

        public IEnumerable<PrimeFactor> PrimeFactors
        {
            get { return primeFactors.Select(p => p); }
        }
    }
}
