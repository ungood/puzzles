using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using NUnit.Framework;
using Puzzles.Common;

namespace Puzzles.Euler.Problems020
{
    public static class Problem020
    {
        public static BigInteger Factorial(long x)
        {
            var value = BigInteger.One;
            for (long i = x; i > 1; i--)
                value *= i;

            return value;
        }
    }

    [TestFixture]
    public class Problem020Test
    {
        [Test]
        public void GivenExample()
        {
            var factorial = Problem020.Factorial(10);
            var sum = factorial.SumDigits(10);
            Assert.AreEqual(3628800, factorial);
            Assert.AreEqual(27, sum);
        }

        [Test]
        public void Solution()
        {
            var answer = Problem020.Factorial(100).SumDigits(10);
            Console.WriteLine("Problem 020: {0}", answer);
            Assert.AreEqual(648, answer);
        }
    }
}
