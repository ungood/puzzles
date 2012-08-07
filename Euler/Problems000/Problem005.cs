using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common;

namespace Puzzles.Euler.Problems000
{
    [TestFixture]
    public class Problem005Tests
    {
        public long Solve(int max)
        {
            return Enumerable.Range(1, max).Select(x => (long)x).Aggregate(MathEx.Lcm);
        }

        [Test]
        public void GivenExample()
        {
            Assert.AreEqual(2520, Solve(10));
        }

        [Test]
        public void Solution()
        {
            var answer = Solve(20);
            Console.WriteLine("Problem 5: {0}", answer);
            Assert.AreEqual(232792560, answer);
        }
    }
}
