using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.Extensions;
using Puzzles.Common.Primes;

namespace Puzzles.Euler.Problem3
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        [Test]
        public void SieveOfEratosthenesTest()
        {
            var generator = new SieveOfEratosthenes();
            generator.Generate().Take(10).AssertSequenceEquals(2L, 3L, 5L, 7L, 11L, 13L, 17L, 19L, 23L, 29L);
        }

        [Test]
        public void GivenExample()
        {
            var factorer = new TrialDivisionFactorer(new SieveOfEratosthenes());
            var factors = factorer.Factor(13195);

            factors.Primes.AssertSequenceEquals(5, 7, 13, 29);
        }

        [Test]
        [Category("Solution")]
        [Category("Slow")]
        public void Solution()
        {
            var factorer = new TrialDivisionFactorer(new SieveOfEratosthenes());
            var factors = factorer.Factor(600851475143L);

            var answer = factors.Primes.OrderByDescending(prime => prime).First();

            Assert.AreEqual(6857, answer);
            Console.WriteLine("Problem 3: {0}", answer);
        }
    }
}
