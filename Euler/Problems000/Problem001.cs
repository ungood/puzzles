using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Puzzles.Euler.Problems000
{
    /// <summary>
    /// Find the sum of all natural numbers less than N that are multiples of the given numbers.
    /// </summary>
    public class Problem001
    {
        private readonly int[] factors;

        public Problem001(params int[] factors)
        {
            this.factors = factors;
        }

        // Example:
        // Add all numbers less than 10 that are multiples of 2 or 3.
        // 2 + 3 + 4 + 6 + 8 + 9 = 11 + 11 + 10 = 32
        // Equiv to:
        //   Add multiples of 2: 2 + 4 + 6 + 8 = 2 * (1 + 2 + 3 + 4) = 2 * the summation of (10-1)/2
        //   Add multiples of 3: 3 + 6 + 9 = 3 * (1 + 2 + 3) = 3 * the summation of (10-1)/3
        //   Subtract multiples of 6: 6 = 6 * 1 = 6 * the summation of (10-1) / 3
        //   20 + 18 - 6 = 32
        // 

        public int Solve(int n)
        {
            return Enumerable.Range(1, n - 1)
                .Where(i => factors.Any(factor => i % factor == 0))
                .Sum();
        }
    }

    [TestFixture]
    public class Problem001Tests
    {
        [Test]
        public void GivenExample()
        {
            var puzzle = new Problem001(3, 5);
            Assert.AreEqual(23, puzzle.Solve(10));
        }

        [Test]
        public void Solution()
        {
            var puzzle = new Problem001(3, 5);
            var answer = puzzle.Solve(1000);
            Console.WriteLine("Problem 1: {0}", answer);
            Assert.AreEqual(answer, puzzle.Solve(1000));
        }
    }
}
