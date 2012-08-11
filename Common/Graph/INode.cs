using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.Graph
{
    public interface INode<T>
    {
        T Data { get; }
    }
}
