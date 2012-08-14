using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.NumberTheory;

namespace Puzzles.Common.Test.NumberTheory
{
    [TestFixture]
    public class FactorerTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            return new TestCaseData[]
            {
                new TestCaseData(new TrialDivisionFactorer()), 
            };
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void PrimeNumbersHaveNoTrivialFactors(IFactorer factorer)
        {
            factorer.FindNonTrivialFactors(1).AssertSequenceEquals();
            factorer.FindNonTrivialFactors(2).AssertSequenceEquals();
            factorer.FindNonTrivialFactors(-1).AssertSequenceEquals();
            factorer.FindNonTrivialFactors(17).AssertSequenceEquals();
            factorer.FindNonTrivialFactors(0).AssertSequenceEquals();
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void CompositeNumbersTest(IFactorer factorer)
        {
            factorer.FindNonTrivialFactors(8).AssertSequenceEquivalentTo(2, 4);
            factorer.FindNonTrivialFactors(60).AssertSequenceEquivalentTo(2, 3, 4, 5, 6, 10, 12, 15, 20, 30);
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void SquareRootsShouldNotIncludeDuplicateFactor(IFactorer factorer)
        {
            factorer.FindNonTrivialFactors(4).AssertSequenceEquivalentTo(2);
            factorer.FindNonTrivialFactors(16).AssertSequenceEquivalentTo(2, 4, 8);
        }
    }
}
