using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.NumberTheory;
using Puzzles.Common.Sequences;

namespace Puzzles.Euler.Problems010
{
    public class Problem012
    {
        private readonly IFactorer factorer;

        public Problem012(IFactorer factorer)
        {
            this.factorer = factorer;
        }

        public long FindFirstNumberInSequenceWithMoreThanXFactors(int numFactors)
        {
            var sequence = new TriangleNumbers();
            return sequence.Generate().First(x => factorer.FindNonTrivialFactors(x).Count() + 2 > numFactors);
        }
    }

    [TestFixture]
    public class Problem012Tests
    {
        [Test]
        public void GivenExample()
        {
            var factorer = new TrialDivisionFactorer();
            var problem = new Problem012(factorer);
            var answer = problem.FindFirstNumberInSequenceWithMoreThanXFactors(5);
            Assert.AreEqual(28, answer);
        }

        [Test]
        public void Solution()
        {
            var factorer = new TrialDivisionFactorer();
            var problem = new Problem012(factorer);
            var answer = problem.FindFirstNumberInSequenceWithMoreThanXFactors(500);
            Console.WriteLine("Problem 012: {0}", answer);
            Assert.AreEqual(76576500, answer);
        }
    }
}
