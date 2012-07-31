using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problem5
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GivenExample()
        {
            Assert.AreEqual(2520, Solve(10));
        }

        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var primeGenerator = new SieveOfEratosthenes();
            var answer = primeGenerator.Generate().TakeWhile(prime => prime <= 20).Aggregate(1L, (left, right) => left * right);
            Console.WriteLine("Problem 5: {0}", answer);
        }
    }
}
