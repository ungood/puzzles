using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.Sequences;

namespace Puzzles.Common.Test.Sequences
{
    [TestFixture]
    public class TriangleNumberTests
    {
        [Test]
        public void TestSequence()
        {
            var triangleNumbers = new TriangleNumberSequence();
            triangleNumbers.Generate().Take(10).AssertSequenceEquals(1, 3, 6, 10, 15, 21, 28, 36, 45, 55);
        }
    }
}
