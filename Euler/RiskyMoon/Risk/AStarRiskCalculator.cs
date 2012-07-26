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
        public double CalculateRisk(IEnumerable<Station> stations, int radius)
        {
            var stationList = stations.ToList();
            var graph = BuildGraph(stationList);

            var northPole = new Station(new CartesianCoordinates(0, 0, radius));
            var southPole = new Station(new CartesianCoordinates(0, 0, radius * -1));

            return CalculateMinimalRisk(graph, northPole, southPole);
        }

        private AdjacencyGraph<Station, Edge<Station>> BuildGraph(IList<Station> stations)
        {
            var graph = new AdjacencyGraph<Station, Edge<Station>>(false);

            graph.AddVertexRange(stations);
            for (int i = 0; i < stations.Count; i++)
            {
                for (int j = 0; j < stations.Count; j++)
                {
                    if (i == j) continue;
                    graph.AddEdge(new Edge<Station>(stations[i], stations[j]));
                }
            }

            return graph;
        }

        public double CalculateMinimalRisk(AdjacencyGraph<Station, Edge<Station>> graph, Station from, Station to)
        {
            Func<Edge<Station>, double> calcWeight = visiting => visiting.Source.CalculateRisk(visiting.Target);
            
            var algorithm = new DijkstraShortestPathAlgorithm<Station, Edge<Station>>(graph, calcWeight);
            var pathRecorder = new VertexPredecessorRecorderObserver<Station, Edge<Station>>();
            var distanceRecorder = new VertexDistanceRecorderObserver<Station, Edge<Station>>(calcWeight); 
            
            using (pathRecorder.Attach(algorithm))
            using(distanceRecorder.Attach(algorithm))
            {
                algorithm.Compute(from);
                IEnumerable<Edge<Station>> path;
                pathRecorder.TryGetPath(to, out path);
                return distanceRecorder.Distances[to];
            }
        }
    }
}
