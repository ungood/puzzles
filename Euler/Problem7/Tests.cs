using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problem7
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var generator = new SieveOfEratosthenes();
            var answer = generator.Generate().ElementAt(10000);
            Console.WriteLine("Problem 7: {0}", answer);
            Assert.AreEqual(104743, answer);
        }
    }
}
