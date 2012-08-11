using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common;
using Puzzles.Common.Test;

namespace Puzzles.Euler.Problems010
{
    public static class Problem014
    {
        public static IEnumerable<long> Generate(long startingNumber)
        {
            var value = startingNumber;
            while(value > 1)
            {
                yield return value;

                if(value % 2 == 0)
                {
                    value /= 2;
                }
                else
                {
                    value = (value * 3) + 1;
                }
            }

            yield return value;
        }

        public static long FindMaxCount(int maxStartingNumber)
        {
            return Enumerable.Range(1, maxStartingNumber)
                .Select(startingNumber => new KeyValuePair<long, long>(startingNumber, Generate(startingNumber).Count()))
                .MaxBy(kvp => kvp.Value).Key;
        }
    }

    [TestFixture]
    public class Problem014Tests
    {
        [Test]
        public void GivenExample()
        {
            var result = Problem014.Generate(13);
            result.AssertSequenceEquals(13, 40, 20, 10, 5, 16, 8, 4, 2, 1);
        }

        [Test]
        public void Solution()
        {
            var answer = Problem014.FindMaxCount(1000000);
            Console.WriteLine("Problem 014: {0}", answer);
            Assert.AreEqual(837799, answer);
        }
    }
}
