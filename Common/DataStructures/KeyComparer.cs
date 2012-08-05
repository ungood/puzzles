using System.Collections.Generic;

namespace Puzzles.Common.DataStructures
{
    public class KeyValuePairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>> 
    {
        private readonly IComparer<TKey> keyComparer;

        public KeyValuePairComparer(IComparer<TKey> keyComparer = null)
        {
            this.keyComparer = keyComparer ?? Comparer<TKey>.Default;
        }

        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return keyComparer.Compare(x.Key, y.Key);
        }
    }
}
