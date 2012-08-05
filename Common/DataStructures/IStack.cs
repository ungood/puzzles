using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DataStructures
{
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty { get; }
    }
}
