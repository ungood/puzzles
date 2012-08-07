using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problems000
{
    [TestFixture]
    public class Problem007Tests
    {
        [Test]
        public void Solution()
        {
            var generator = new SieveOfEratosthenes();
            var answer = generator.Generate().ElementAt(10000);
            Console.WriteLine("Problem 7: {0}", answer);
            Assert.AreEqual(104743, answer);
        }
    }
}
