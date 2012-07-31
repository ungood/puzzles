using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Spatial
{
    public static class SpatialMath
    {
        public static double GreatCircleDistance(LatLongRadians from, LatLongRadians to)
        {
            var inner = Math.Sin(from.Latitude) * Math.Sin(to.Latitude) +
                Math.Cos(from.Latitude) * Math.Cos(to.Latitude) *
                Math.Cos(from.Longitude - to.Longitude);
            if (inner < -1)
                inner = -1;
            if (inner > 1)
                inner = 1;

            return from.Radius * Math.Acos(inner);
        }
    }
}
