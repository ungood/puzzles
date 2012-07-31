using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DiscreteMath
{
    public class Fibonacci
    {
        private readonly long first;
        private readonly long second;

        public Fibonacci() : this(1, 2)
        {
            
        }

        public Fibonacci(long first, long second)
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
