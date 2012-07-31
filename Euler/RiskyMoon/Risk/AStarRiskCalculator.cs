using System;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common;
using Puzzles.Common.Extensions;
using Puzzles.Common.Spatial;
using QuickGraph;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.ShortestPath;

namespace Puzzles.Euler.RiskyMoon.Risk
{
    public class AStarRiskCalculator : IRiskCalculator
    {
        public RiskResult CalculateRisk(IEnumerable<Station> stations, int radius)
        {
            var stationList = stations.OrderByDescending(x => x.CartesianLocation.Z).ToList();
            var graph = BuildGraph(stationList, radius);

            var northPole = new Station(new CartesianCoordinates(0, 0, radius));
            var southPole = new Station(new CartesianCoordinates(0, 0, radius * -1));

            return CalculateMinimalRisk(graph, northPole, southPole);
        }

        private DelegateVertexAndEdgeListGraph<Station, StationPath> BuildGraph(IList<Station> sortedStations, int radius)
        {
            var maxDeltaZ = MathEx.Pow2((int)MathEx.Lg2(radius)); // The max deltaz is the next lowest power of 2.

            return new DelegateVertexAndEdgeListGraph<Station, StationPath>(sortedStations,
                delegate(Station source, out IEnumerable<StationPath> result)
                {
                    result = GetNeighbors(source, sortedStations, maxDeltaZ).Select(target => new StationPath(source, target));
                    return true;
                });
        }

        private static IEnumerable<Station> GetNeighbors(Station source, IEnumerable<Station> sortedStations, int maxDeltaZ)
        {
            var maxZ = source.CartesianLocation.Z;
            var minZ = maxZ - maxDeltaZ;

            var stations = sortedStations.SkipWhile(station => station.CartesianLocation.Z >= maxZ)
                .TakeWhile(station => station.CartesianLocation.Z >= minZ).ToList();

            return stations;
        }

        public RiskResult CalculateMinimalRisk(IVertexAndEdgeListGraph<Station, StationPath> graph, Station from, Station to)
        {
            Func<StationPath, double> calcWeight = visiting => visiting.Risk;
            Func<Station, double> calcHeuristic = visiting => visiting.CalculateRisk(to);

            var algorithm = new AStarShortestPathAlgorithm<Station, StationPath>(graph, calcWeight, calcHeuristic);
            var pathRecorder = new VertexPredecessorRecorderObserver<Station, StationPath>();
            using (pathRecorder.Attach(algorithm))
            {
                algorithm.Compute(from);
                IEnumerable<StationPath> path;
                pathRecorder.TryGetPath(to, out path);

                return new RiskResult(path, from.RadianLocation.Radius);
            }
        }
    }
}
