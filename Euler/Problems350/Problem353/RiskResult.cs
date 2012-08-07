using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Euler.RiskyMoon
{
    public class RiskResult
    {
        public double Radius { get; private set; }

        public IEnumerable<StationPath> Path { get; private set; }

        public double TotalRisk { get; private set; }

        public double TotalDistance { get; private set; }

        public double TotalDistanceRatio { get; private set; }

        public RiskResult(IEnumerable<StationPath> path, double radius)
        {
            Radius = radius;
            Path = path;
            TotalRisk = path.Sum(x => x.Risk);
            TotalDistance = path.Sum(x => x.Distance);
            TotalDistanceRatio = TotalDistance / (Math.PI * radius);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var path in Path)
            {
                sb.AppendFormat("{0}\n", path);
            }
            sb.AppendFormat("Hops: {0}\n", Path.Count());
            sb.AppendFormat("Total Distance: {0:N4}({1:N4})\n", TotalDistance, TotalDistanceRatio);
            sb.AppendFormat("Total Risk: {0:N10}\n", TotalRisk);
            return sb.ToString();
        }
    }
}
