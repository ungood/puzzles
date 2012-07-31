using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Euler.RiskyMoon.Lattice;
using Puzzles.Euler.RiskyMoon.Risk;

namespace Puzzles.Euler.RiskyMoon.Tests
{
    [TestFixture]
    public class RiskyMoonSolution
    {
        [Test]
        [Category("Solution, Slow")]
        public void PrintSolution()
        {
            var latticeCalculator = new SliceSphereLatticeCalculator(new TurtleCircleLatticeCalculator());
            var riskCalculator = new AStarRiskCalculator();

            var puzzle = new RiskyMoonPuzzle(latticeCalculator, riskCalculator);

            Console.WriteLine("Solution: {0:N10}", puzzle.Solve());
        }
    }
}
