using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Sequences
{
    public class TriangleNumbers
    {
        public IEnumerable<long> Generate()
        {
            long value = 1;
            long sum = 0;

            while(true)
            {
                sum += value++;
                yield return sum;
            }
        }
    }
}
