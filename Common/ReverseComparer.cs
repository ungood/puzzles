using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common
{
    public class ReverseComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> forwardComparer;

        public ReverseComparer(IComparer<T> forwardComparer)
        {
            this.forwardComparer = forwardComparer;
        }

        public int Compare(T x, T y)
        {
            return forwardComparer.Compare(y, x);
        }
    }
}
