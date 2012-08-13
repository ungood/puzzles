using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Graph
{
    public interface IImplicitGraph<TVertex>
    {
        IEnumerable<TVertex> GetNeighbors(TVertex vertex);
    }

    public class DelegateGraph<TVertex> : IImplicitGraph<TVertex>
    {
        private readonly Func<TVertex, IEnumerable<TVertex>> getNeighbors;

        public DelegateGraph(Func<TVertex, IEnumerable<TVertex>> getNeighbors)
        {
            this.getNeighbors = getNeighbors;
        }

        public IEnumerable<TVertex> GetNeighbors(TVertex vertex)
        {
            return getNeighbors(vertex);
        }
    }
}
