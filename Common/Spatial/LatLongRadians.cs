using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Spatial
{
    public struct LatLongRadians : IEquatable<LatLongRadians>, IComparable<LatLongRadians>
    {
        public double Radius { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public LatLongRadians(double radius, double latitude, double longitude)
            : this()
        {
            Longitude = longitude;
            Latitude = latitude;
            Radius = radius;
        }

        public static explicit operator LatLongRadians(CartesianCoordinates cartesian)
        {
            var r = Math.Sqrt((cartesian.X * cartesian.X) + (cartesian.Y * cartesian.Y) + (cartesian.Z * cartesian.Z));
            return new LatLongRadians(
                r,
                Math.Asin(cartesian.Z / r),
                Math.Atan2(cartesian.Y, cartesian.X));
        }

        public static explicit operator LatLongRadians(LatLongDegrees degrees)
        {
            return new LatLongRadians(degrees.Radius,
                MathEx.ToRadians(degrees.Latitude),
                MathEx.ToRadians(degrees.Longitude));
        }

        public override string ToString()
        {
            return ((LatLongDegrees)this).ToString();
        }

        #region Equality

        public bool Equals(LatLongRadians other)
        {
            return other.Radius.Equals(Radius) && other.Latitude.Equals(Latitude) && other.Longitude.Equals(Longitude);
        }

        public int CompareTo(LatLongRadians other)
        {
            return Equals(other) ? 0 : -1;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(obj.GetType() != typeof(LatLongRadians))
            {
                return false;
            }
            return Equals((LatLongRadians)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Radius.GetHashCode();
                result = (result * 397) ^ Latitude.GetHashCode();
                result = (result * 397) ^ Longitude.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(LatLongRadians left, LatLongRadians right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LatLongRadians left, LatLongRadians right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
