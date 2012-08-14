using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.Sequences;
using Puzzles.Common.Test;

namespace Puzzles.Euler.Problems000
{
    public static class Problem002
    {
        public static long SumEvenFibonacciValues(int max)
        {
            var fib = new FibonacciSequence(1, 2);

            return fib.Generate()
                .TakeWhile(n => n < max)
                .Where(n => n % 2 == 0)
                .Sum();
        }
    }

    [TestFixture]
    public class Problem002Tests
    {
        [Test]
        public void FibonacciTest()
        {
            var firstTen = new FibonacciSequence(1, 2).Generate().Take(10);
            firstTen.AssertSequenceEquals(1, 2, 3, 5, 8, 13, 21, 34, 55, 89);
        }

        [Test]
        public void GivenExample()
        {
            var actual = Problem002.SumEvenFibonacciValues(90);
            Assert.AreEqual(44, actual);
        }

        [Test]
        public void Solution()
        {
            var answer = Problem002.SumEvenFibonacciValues(4000000);
            Console.WriteLine("Problem 2: {0}", answer);
            Assert.AreEqual(4613732, answer);
        }
    }
}
