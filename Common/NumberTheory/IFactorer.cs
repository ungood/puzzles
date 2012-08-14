using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.NumberTheory
{
    public interface IFactorer
    {
        IEnumerable<long> FindNonTrivialFactors(long n);
    }
}
