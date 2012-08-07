using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Puzzles.Euler.Problems000
{
    /// <summary>
    /// Find the largest N-digit palindrome number.
    /// </summary>
    public class Problem004
    {
        private int max;

        public Problem004(int numberOfDigits)
        {
            max = (int)(Math.Pow(10, numberOfDigits)) - 1;
        }

        public int Solve()
        {
            var query = from left in Enumerable.Range(1, max).AsParallel()
                from right in Enumerable.Range(1, max)
                select left * right;

            return query.Where(IsPalindrome).Max();
        }

        private static bool IsPalindrome(int value)
        {
            var digits = GetDigits(value).ToArray();

            var first = 0;
            var last = digits.Length - 1;

            while(first < last)
            {
                if (digits[first] != digits[last])
                    return false;
                first++;
                last--;
            }

            return true;
        }

        private static IEnumerable<int> GetDigits(int value)
        {
            while(value > 0)
            {
                yield return value % 10;
                value /= 10;
            }
        } 
    }

    [TestFixture]
    public class Problem004Tests
    {
        [Test]
        public void GivenExample()
        {
            var puzzle = new Problem004(2);
            Assert.AreEqual(9009, puzzle.Solve());
        }

        [Test]
        public void Solution()
        {
            var puzzle = new Problem004(3);

            var answer = puzzle.Solve();
            Assert.AreEqual(906609, answer);
            Console.WriteLine("Puzzle 4: {0}", answer);
        }
    }
}
