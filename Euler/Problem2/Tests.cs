using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.DiscreteMath;
using Puzzles.Common.Extensions;

namespace Puzzles.Euler.Problem2
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        [Test]
        public void FibonacciTest()
        {
            var firstTen = new Fibonacci(1, 2).Generate().Take(10);
            firstTen.AssertSequenceEquals(1, 2, 3, 5, 8, 13, 21, 34, 55, 89);
        }

        [Test]
        public void GivenExample()
        {
            var actual = Puzzle.SumEvenFibonacciValues(90);
            Assert.AreEqual(44, actual);
        }

        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var answer = Puzzle.SumEvenFibonacciValues(4000000);
            Console.WriteLine("Problem 2: {0}", answer);
            Assert.AreEqual(4613732, answer);
        }
    }
}
