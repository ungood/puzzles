using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Primes
{
    public interface IPrimeGenerator<T>
    {
        IEnumerable<T> Generate();
    }
}
