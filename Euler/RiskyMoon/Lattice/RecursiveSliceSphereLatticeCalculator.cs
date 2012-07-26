using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Lattice
{
    class RecursiveSliceSphereLatticeCalculator : ISphereLatticeCalculator
    {
        private readonly ICircleLatticeCalculator circleLatticeCalculator;

        public RecursiveSliceSphereLatticeCalculator(ICircleLatticeCalculator circleLatticeCalculator)
        {
            this.circleLatticeCalculator = circleLatticeCalculator;
        }
        
        public IEnumerable<CartesianCoordinates> FindLatticePoints(int radius)
        {
            var slices = Enumerable.Range(radius * -1, radius * 2 + 1);

            return slices.AsParallel().SelectMany(slice => circleLatticeCalculator.FindLatticePoints(radius, slice));
        }
    }
}
