using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Puzzles.Common.DataStructures;

namespace Puzzles.Common.Graph
{
    public class VertexAndEdgeSetGraph<TVertex> : IImplicitGraph<TVertex>
    {
        public IEnumerable<TVertex> GetNeighbors(TVertex vertex)
        {
            yield break;
        }
    }
}
