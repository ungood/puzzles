using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Sequences
{
    public class FibonacciSequence : ISequence
    {
        private readonly long first;
        private readonly long second;

        public FibonacciSequence() : this(1, 2)
        {
            
        }

        public FibonacciSequence(long first, long second)
        {
            this.first = first;
            this.second = second;
        }

        public IEnumerable<long> Generate()
        {
            var previous = first;
            var current = second;

            yield return previous;

            while(true)
            {
                yield return current;
                var temp = previous;
                previous = current;
                current = current + temp;
            }
        } 
    }
}
