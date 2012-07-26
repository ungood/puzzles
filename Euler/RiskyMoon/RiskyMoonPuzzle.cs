using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Extensions;
using Puzzles.Euler.RiskyMoon.Lattice;
using Puzzles.Euler.RiskyMoon.Risk;

namespace Puzzles.Euler.RiskyMoon
{
    public class RiskyMoonPuzzle
    {
        private readonly ISphereLatticeCalculator latticeCalculator;
        private readonly IRiskCalculator riskCalculator;

        public RiskyMoonPuzzle(ISphereLatticeCalculator latticeCalculator, IRiskCalculator riskCalculator)
        {
            this.latticeCalculator = latticeCalculator;
            this.riskCalculator = riskCalculator;
        }

        public double Solve(int start, int count)
        {
            return Enumerable.Range(start, count)
                .AsParallel()
                .Select(n => n.Pow2() - 1)
                .Sum(r => Solve(r));
        }

        public double Solve(int radius)
        {
            var latticePoints = latticeCalculator.FindLatticePoints(radius);
            return riskCalculator.CalculateRisk(latticePoints.Select(point => new Station(point)), radius);
        }
    }
}
