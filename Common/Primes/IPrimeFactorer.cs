using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Primes
{
    public interface IPrimeFactorer
    {
        PrimeFactorization Factor(long value);
    }
}
