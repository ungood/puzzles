using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Puzzles.Common.DataStructures
{
    public class BucketSet<T> : ISet<T>
    {
        public const int DefaultNumBuckets = 67;

        private readonly IEqualityComparer<T> equalityComparer;
        private readonly LinkedList<T>[] buckets;
        
        public BucketSet(int numBuckets = DefaultNumBuckets, IEqualityComparer<T> equalityComparer = null) 
        {
            this.equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
            if(numBuckets < 1)
                throw new ArgumentOutOfRangeException("numBuckets", "The number of buckets must be greater than 0.");

            buckets = new LinkedList<T>[numBuckets];
            for(int i = 0; i < numBuckets; i++)
                buckets[i] = new LinkedList<T>();
        }

        public bool Add(T item)
        {
            var bucket = GetBucket(item);
            if(bucket.Any(current => equalityComparer.Equals(current, item)))
            {
                return false;
            }

            bucket.AddLast(item);
            return true;
        }

        public bool Contains(T item)
        {
            return GetBucket(item).Any(current => equalityComparer.Equals(current, item));
        }

        private LinkedList<T> GetBucket(T item)
        {
            var bucketIndex = Math.Abs(equalityComparer.GetHashCode(item)) % buckets.Length;
            return buckets[bucketIndex];
        }
    }
}
