using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;

namespace Puzzles.Euler.RiskyMoon.Risk
{
    public interface IRiskCalculator
    {
        RiskResult CalculateRisk(IEnumerable<Station> stations, int radius);
    }
}
