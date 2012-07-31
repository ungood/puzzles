using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.Euler.Problem1
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        [Test]
        public void GivenExample()
        {
            var puzzle = new Puzzle(3, 5);
            Assert.AreEqual(23, puzzle.Solve(10));
        }

        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var puzzle = new Puzzle(3, 5);
            var answer = puzzle.Solve(1000);
            Console.WriteLine("Problem 1: {0}", answer);
            Assert.AreEqual(answer, puzzle.Solve(1000));
        }
    }
}
