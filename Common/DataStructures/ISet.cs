using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DataStructures
{
    public interface ISet<in T>
    {
        bool Add(T item);
        bool Contains(T item);
    }
}
