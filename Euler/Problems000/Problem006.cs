using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Puzzles.Euler.Problems000
{
    [TestFixture]
    public class Problem006Tests
    {
        public long Solve(int n)
        {
            var sumOfSquares = (n * (n + 1) * (2 * n + 1)) / 6;
            var sum = (n * (n + 1)) / 2;
            var squareOfSums = sum * sum;
            
            return squareOfSums - sumOfSquares;
        }

        [Test]
        public void GivenExample()
        {
            Assert.AreEqual(2640, Solve(10));
        }

        [Test]
        public void Solution()
        {
            var answer = Solve(100);
            Console.WriteLine("Problem 6: {0}", answer);
            Assert.AreEqual(25164150, answer);
        }
    }
}
