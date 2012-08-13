using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Common.DataStructures;

namespace Puzzles.Common.Graph
{
    public class AStarAlgorithm<TVertex>
    {
        private readonly IImplicitGraph<TVertex> graph;
        private readonly Func<TVertex, TVertex, double> calcWeight;
        private readonly Func<TVertex, double> calcHeuristic;
        private readonly IComparer<double> comparer;

        public AStarAlgorithm(
            IImplicitGraph<TVertex> graph,
            Func<TVertex, TVertex, double> calcWeight,
            Func<TVertex, double> calcHeuristic,
            IComparer<double> comparer = null)
        {
            this.graph = graph;
            this.calcWeight = calcWeight;
            this.calcHeuristic = calcHeuristic;
            comparer = comparer ?? Comparer<double>.Default;
            this.comparer = new ReverseComparer<double>(comparer);
        }

        public IEnumerable<TVertex> FindShortestPath(TVertex from, TVertex to)
        {
            var openSet = new BinaryHeap<double, TVertex>(comparer);
            openSet.Insert(calcHeuristic(from), from);

            var closedSet = new BucketSet<TVertex>();

            var cameFrom = new Dictionary<TVertex, TVertex>();
            var gScore = new Dictionary<TVertex, double> {{from, 0}};

            while(!openSet.IsEmpty)
            {
                var current = openSet.PullMax();
                if(current.Equals(to))
                {
                    var result = new Stack<TVertex>();
                    while(cameFrom.ContainsKey(current))
                    {
                        result.Push(current);
                        current = cameFrom[current];
                    }

                    result.Push(current);
                    return result;
                }

                closedSet.Add(current);

                var unexaminedNeighbors = graph.GetNeighbors(current)
                    .Where(vertex => !closedSet.Contains(vertex));
                foreach(var neighbor in unexaminedNeighbors)
                {
                    var estimatedWeight = gScore[current] + calcWeight(current, neighbor);
                    if(!gScore.ContainsKey(neighbor) || estimatedWeight < gScore[neighbor])
                    {
                        openSet.Insert(estimatedWeight, neighbor);
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = estimatedWeight;
                    }
                }
            }

            return null; // If the open set if empty, it means we failed to find any path to the target.
        }


    }
}
