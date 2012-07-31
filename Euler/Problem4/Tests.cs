using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Puzzles.Euler.Problem4
{
    [TestFixture(Category="Solved")]
    public class Tests
    {
        [Test]
        public void GivenExample()
        {
            var puzzle = new Puzzle(2);
            Assert.AreEqual(9009, puzzle.Solve());
        }

        [Test]
        [Category("Solution")]
        public void Solution()
        {
            var puzzle = new Puzzle(3);

            var answer = puzzle.Solve();
            Assert.AreEqual(906609, answer);
            Console.WriteLine("Puzzle 4: {0}", answer);
        }
    }
}
