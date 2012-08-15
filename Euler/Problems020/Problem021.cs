using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.NumberTheory;
using Puzzles.Common.Sequences;

namespace Puzzles.Euler.Problems020
{
    public class Problem021
    {
        private readonly AmicableNumbers sequence;

        public Problem021(IFactorer factorer)
        {
            sequence = new AmicableNumbers(factorer);
        }

        public long Solve(int max)
        {
            return sequence.Generate().Select(x => x.Item1).TakeWhile(x => x < max).Sum();
        }
    }

    [TestFixture]
    public class Problem021Tests
    {
        [Test]
        public void Solution()
        {
            var problem = new Problem021(new TrialDivisionFactorer());
            var answer = problem.Solve(10000);
            Console.WriteLine("Problem 021: {0}", answer);
            Assert.AreEqual(31626, answer);
        }
    }
}
