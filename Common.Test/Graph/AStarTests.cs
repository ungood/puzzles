using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Puzzles.Common.Graph;

namespace Puzzles.Common.Test.Graph
{
    [TestFixture]
    public class AStarTests
    {
        private class SampleGraph : IImplicitGraph<char>
        {
            private readonly Dictionary<char, Tuple<int, int>> positions;
            private readonly Dictionary<char, IEnumerable<char>> neighbors;
            
            // A-->B-->C-->D-->E
            // V       V       ^
            // F------>G------>H
            // |               V       
            // I<--------------J
            public SampleGraph()
            {
                positions = new Dictionary<char, Tuple<int, int>>
                {
                    {'A', new Tuple<int, int>(0, 0)},
                    {'B', new Tuple<int, int>(1, 0)},
                    {'C', new Tuple<int, int>(2, 0)},
                    {'D', new Tuple<int, int>(3, 0)},
                    {'E', new Tuple<int, int>(4, 0)},
                    {'F', new Tuple<int, int>(0, 1)},
                    {'G', new Tuple<int, int>(2, 1)},
                    {'H', new Tuple<int, int>(4, 1)},
                    {'I', new Tuple<int, int>(0, 2)},
                    {'J', new Tuple<int, int>(4, 2)},
                };

                neighbors = new Dictionary<char, IEnumerable<char>>
                {
                    {'A', new char[] {'B', 'F'}},
                    {'B', new char[] {'C'}},
                    {'C', new char[] {'D', 'G'}},
                    {'D', new char[] {'E'}},
                    {'E', new char[] {}},
                    {'F', new char[] {'G', 'I'}},
                    {'G', new char[] {'H'}},
                    {'H', new char[] {'E', 'J'}},
                    {'I', new char[] {'I', 'F'}}, // I has a loop
                    {'J', new char[] {'I'}},
                };
            }

            public IEnumerable<char> GetNeighbors(char vertex)
            {
                return neighbors[vertex];
            }

            public double CalcDistance(char source, char target)
            {
                var x = positions[target].Item1 - positions[source].Item1;
                var y = positions[target].Item2 - positions[source].Item2;

                return x * x + y * y;
            }
        }

        private string FindPath(char from, char to)
        {
            var graph = new SampleGraph();
            var algorithm = new AStarAlgorithm<char>(graph, graph.CalcDistance, a => graph.CalcDistance(a, 'J'));
            var path = algorithm.FindShortestPath(from, to);
            if (path == null)
                return null;
            return string.Join("", path);
        }
            
        [Test]
        public void FindShortestPathTest()
        {
            Assert.AreEqual("ABCGHJ", FindPath('A', 'J'));
        }

        [Test]
        public void FindShortestPathBetweenNeighbors()
        {
            Assert.AreEqual("FG", FindPath('F', 'G'));
        }

        [Test]
        public void PathShouldBeNullIfNoneFound()
        {
            Assert.AreEqual(null, FindPath('E', 'I'));
        }

        [Test]
        public void PathShouldIgnoreLoops()
        {
            Assert.AreEqual("IFGHE", FindPath('I', 'E'));
        }
    }
}
