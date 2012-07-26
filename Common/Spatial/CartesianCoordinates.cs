using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Spatial
{
    public struct CartesianCoordinates : IEquatable<CartesianCoordinates>, IComparable<CartesianCoordinates>
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public int Z { get; private set; }

        public CartesianCoordinates(int x, int y, int z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(CartesianCoordinates other)
        {
            return other.X.Equals(X) && other.Y.Equals(Y) && other.Z.Equals(Z);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(obj.GetType() != typeof(CartesianCoordinates))
            {
                return false;
            }
            return Equals((CartesianCoordinates)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = X.GetHashCode();
                result = (result * 397) ^ Y.GetHashCode();
                result = (result * 397) ^ Z.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(CartesianCoordinates left, CartesianCoordinates right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CartesianCoordinates left, CartesianCoordinates right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(CartesianCoordinates other)
        {
            var c = X.CompareTo(other.X);
            if (c == 0)
                c = Y.CompareTo(other.Y);
            if (c == 0)
                c = Z.CompareTo(other.Z);
            return c;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public long MagnitudeSquared
        {
            get { return ((long)X * X) + ((long)Y * Y) + ((long)Z * Z); }
        }
    }
}
