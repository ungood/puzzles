using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Lattice
{
    public class ParallelNaiveSphereLatticeCalculator : ISphereLatticeCalculator
    {
        public IEnumerable<CartesianCoordinates> FindLatticePoints(int radius)
        {
            var min = radius * -1;

            var query = from x in Enumerable.Range(min, radius * 2 + 1).AsParallel()
                        from y in Enumerable.Range(min, radius * 2 + 1)
                        from z in Enumerable.Range(min, radius * 2 + 1)
                        let distance = Math.Sqrt(x * x + y * y + z * z)
                        where Math.Abs(distance - radius) < double.Epsilon
                        select new CartesianCoordinates(x, y, z);
            return query;
        }
    }
}
