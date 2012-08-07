using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.Spatial;
using QuickGraph;

namespace Puzzles.Euler.RiskyMoon
{
    public class StationPath : Edge<Station>, IEquatable<StationPath>
    {
        public StationPath(Station source, Station target)
            : base(source, target)
        {
            Distance = SpatialMath.GreatCircleDistance(source.RadianLocation, target.RadianLocation);
            var x = Distance / (source.RadianLocation.Radius * Math.PI);
            Risk = x * x;
        }

        public double Risk { get; private set; }

        public double Distance { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} -> {1} Distance: {2:0.0000} Risk: {3:0.00000}", Source, Target, Distance, Risk);
        }

        public bool Equals(StationPath other)
        {
            return Source.Equals(Source) && Target.Equals(Target);
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Target.GetHashCode();
        }
    }
}
