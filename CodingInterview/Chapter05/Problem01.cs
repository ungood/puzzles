using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.CodingInterview.Chapter05
{
    public static class Problem01
    {
        public static int Insert(int source, int target, int i, int j)
        {
            // Create a bit. pattern 0000111100 where the 1s start at bit j and end at bit i
            var mask = 0;
            for (int bit = i; bit <= j; bit++)
                mask |= 1 << bit;
            Console.WriteLine(Convert.ToString(mask, 2));

            target = target << i & mask;

            // set 1s
            source |= target;
            target ^= mask;
            source &= target;
            Console.WriteLine(Convert.ToString(source, 2));

            return source;
        }
    }

    [TestFixture]
    public class Problem01Tests
    {
        [Test]
        public void GivenExample()
        {
            var source = Convert.ToInt32("10001111100", 2);
            var target = Convert.ToInt32("10011", 2);
            var actual = Convert.ToString(Problem01.Insert(source, target, 2, 6), 2);

            Assert.AreEqual("10001001100", actual);
        }
    }
}
