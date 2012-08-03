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
    public class CircleLatticeTests
    {
        public IEnumerable<TestCaseData> GetImplementations()
        {
            var turtle = new TurtleCircleLatticeCalculator();

            return new[]
            {
                new TestCaseData(turtle)
            };
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void UnitCircleTest(ICircleLatticeCalculator calculator)
        {
            var unitCircle = calculator.FindLatticePoints(1, 0);

            unitCircle.AssertSequenceEquivalentTo(
                new CartesianCoordinates(0, -1, 0),
                new CartesianCoordinates(0, 1, 0),
                new CartesianCoordinates(-1, 0, 0),
                new CartesianCoordinates(1, 0, 0));
        }

        [Test]
        [TestCaseSource("GetImplementations")]
        public void RadiusFiveTest(ICircleLatticeCalculator calculator)
        {
            var latticePoints = calculator.FindLatticePoints(5, 0);

            latticePoints.AssertSequenceEquivalentTo(
                new CartesianCoordinates(0, -5, 0),
                new CartesianCoordinates(0, 5, 0),
                new CartesianCoordinates(-5, 0, 0),
                new CartesianCoordinates(5, 0, 0),
                new CartesianCoordinates(4, 3, 0),
                new CartesianCoordinates(3, 4, 0),
                new CartesianCoordinates(-4, 3, 0),
                new CartesianCoordinates(-3, 4, 0),
                new CartesianCoordinates(4, -3, 0),
                new CartesianCoordinates(3, -4, 0),
                new CartesianCoordinates(-4, -3, 0),
                new CartesianCoordinates(-3, -4, 0));
        }
    }
}
