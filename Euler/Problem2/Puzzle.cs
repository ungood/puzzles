using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Puzzles.Common.DiscreteMath;

namespace Puzzles.Euler.Problem2
{
    public static class Puzzle
    {
        public static long SumEvenFibonacciValues(int max)
        {
            var fib = new Fibonacci(1, 2);

            return fib.Generate()
                .TakeWhile(n => n < max)
                .Where(n => n % 2 == 0)
                .Sum();
        }
    }
}
