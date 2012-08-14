using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Sequences
{
    public interface ISequence
    {
        IEnumerable<long> Generate();
    }
}
