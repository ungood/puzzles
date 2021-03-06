﻿using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Lattice
{
    public interface ISphereLatticeCalculator
    {
        IEnumerable<CartesianCoordinates> FindLatticePoints(int radius);
    }
}
