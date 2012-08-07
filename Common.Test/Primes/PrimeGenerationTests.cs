using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using NUnit.Framework;
using Puzzles.Common.Primes;

namespace Puzzles.Common.Test.Primes
{
    [TestFixture]
    public class PrimeGenerationTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            return new[]
            {
                new TestCaseData(new SieveOfEratosthenes())
            };
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void TimeFirstTenThousandPrimes(IPrimeGenerator generator)
        {
            var sw = new Stopwatch();
            sw.Start();

            var primes = generator.Generate().Take(10000).ToList();

            sw.Stop();
            Console.WriteLine("Time: {0}", sw.Elapsed);
        }
    }
}
