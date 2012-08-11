using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.Euler.Problems010
{
    public static class Problem015
    {
        /// <summary>
        /// Return the number of paths on a grid from the given starting position to 0,0
        /// assuming you can only move in a orthangonal direction towards 0,0.
        /// </summary>
        public static long NumberOfPaths(int x, int y)
        {
            if (x == 0 && y == 1)
                return 1;
            
            if (x == 1 && y == 0)
                return 1;

            if (x == 0)
                return NumberOfPaths(x, y - 1);
            
            if (y == 0)
                return NumberOfPaths(x - 1, y);

            return NumberOfPaths(x - 1, y) + NumberOfPaths(x, y - 1);
        }

        /// <summary>
        /// Rturn the number of paths on a NxN grid from one corner to the other.
        /// We can find this by finding the square of the number of paths from one corner to the diagonal mid-line
        /// </summary>
        public static long Solve(int n)
        {
            return Enumerable.Range(0, n + 1).Select(x =>
            {
                var y = n - x;
                var paths = NumberOfPaths(x, y);
                return paths * paths;
            }).Sum();
        }
    }

    [TestFixture]
    public class Problem015Tests
    {
        [Test]
        public void GivenExample()
        {
            var answer = Problem015.Solve(2);
            Assert.AreEqual(6, answer);
        }

        [Test]
        public void Solution()
        {
            var answer = Problem015.Solve(20);
            Console.WriteLine("Problem 015: {0}", answer);
            Assert.AreEqual(137846528820, answer);
        }
    }
}
