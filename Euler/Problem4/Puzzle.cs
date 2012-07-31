using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Euler.Problem4
{
    public class Puzzle
    {
        private int max;

        public Puzzle(int numberOfDigits)
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
}
