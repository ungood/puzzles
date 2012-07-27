using System;
using System.Collections.Generic;
using System.Linq;
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
            var stationList = stations.ToList();
            var graph = BuildGraph(stationList);

            var northPole = new Station(new CartesianCoordinates(0, 0, radius));
            var southPole = new Station(new CartesianCoordinates(0, 0, radius * -1));

            return CalculateMinimalRisk(graph, northPole, southPole);
        }

        private DelegateVertexAndEdgeListGraph<Station, StationPath> BuildGraph(IList<Station> stations)
        {
            return new DelegateVertexAndEdgeListGraph<Station, StationPath>(stations,
                delegate(Station station, out IEnumerable<StationPath> result) {
                    result = stations.Select(target => new StationPath(station, target));
                    return true;
                });

            //var graph = new AdjacencyGraph<Station, StationPath>(false);

            //graph.AddVertexRange(stations);
            //for (int i = 0; i < stations.Count; i++)
            //{
            //    for (int j = 0; j < stations.Count; j++)
            //    {
            //        if (i == j) continue;
            //        graph.AddEdge(new StationPath(stations[i], stations[j]));
            //    }
            //}

            //return graph;
        }

        public RiskResult CalculateMinimalRisk(IVertexAndEdgeListGraph<Station, StationPath> graph, Station from, Station to)
        {
            Func<StationPath, double> calcWeight = visiting => visiting.Risk;
            
            var algorithm = new DijkstraShortestPathAlgorithm<Station, StationPath>(graph, calcWeight);
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
