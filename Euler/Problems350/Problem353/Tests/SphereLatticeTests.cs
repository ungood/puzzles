using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Puzzles.Common.Spatial;
using Puzzles.Common.Test;
using Puzzles.Euler.RiskyMoon.Lattice;

namespace Puzzles.Euler.RiskyMoon.Tests
{
    [TestFixture]
    public class SphereLatticeTests
    {
        public IEnumerable<ISphereLatticeCalculator> GetImplementations()
        {
            return new ISphereLatticeCalculator[]
            {
                new ParallelNaiveSphereLatticeCalculator(),
                //new RecursiveCubesSphereLatticeCalculator(), <-- Not fully functioning
                new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator()),
            };
        }

        public IEnumerable<TestCaseData> GetTestCaseData()
        {
            return GetImplementations().Select(x => new TestCaseData(x));
        }
        
        [Test]
        [TestCaseSource("GetImplementations")]
        public void UnitSphereTest(ISphereLatticeCalculator calculator)
        {
            var latticePoints = calculator.FindLatticePoints(1);

            latticePoints.AssertSequenceEquivalentTo(
                new CartesianCoordinates(0, 0, 1),
                new CartesianCoordinates(0, 1, 0),
                new CartesianCoordinates(1, 0, 0),
                new CartesianCoordinates(0, 0, -1),
                new CartesianCoordinates(0, -1, 0),
                new CartesianCoordinates(-1, 0, 0));
        }

        [Test]
        public void CompareSliceToNaiveForVariousRadii([Range(2, 20)] int radius)
        {
            var naive = new ParallelNaiveSphereLatticeCalculator();
            var slice = new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator());

            var expected = naive.FindLatticePoints(radius).ToArray();
            var actual = slice.FindLatticePoints(radius);

            actual.AssertSequenceEquivalentTo(expected);
        }
    }
}
