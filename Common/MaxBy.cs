using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common
{
    public static partial class EnumerableEx
    {
        public static T MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer = null)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            if(keySelector == null)
                throw new ArgumentNullException("keySelector");

            comparer = comparer ?? Comparer<TKey>.Default;

            using(var enumerator = source.GetEnumerator())
            {
                if(!enumerator.MoveNext())
                    throw new InvalidOperationException("Sequence contains no elements.");

                var maxValue = enumerator.Current;
                var maxKey = keySelector(maxValue);

                while(enumerator.MoveNext())
                {
                    var currentKey = keySelector(enumerator.Current);
                    if(comparer.Compare(currentKey, maxKey) > 0)
                    {
                        maxKey = currentKey;
                        maxValue = enumerator.Current;
                    }
                }

                return maxValue;
            }
        }
    }
}
