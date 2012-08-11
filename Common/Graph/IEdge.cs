using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Graph
{
    public interface IEdge<T>
    {
        INode<T> Source { get; }
        INode<T> Target { get; } 
    }
}
