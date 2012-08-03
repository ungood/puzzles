using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problem10
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        public long Solve(long max)
        {
            var generator = new SieveOfEratosthenes();

            return generator.Generate().TakeWhile(x => x < max).Sum();
        }

        [Test]
        public void GivenExample()
        {
            Assert.AreEqual(17, Solve(10));
        }

        [Test]
        [Category("Solution")]
        [Category("Slow")]
        public void Solution()
        {
            var answer = Solve(2000000L);
            Console.WriteLine("Problem 10: {0}", answer);
            Assert.AreEqual(142913828922, answer);
        }
    }
}
