using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles.Common.Spatial
{
    public struct LatLongDegrees : IEquatable<LatLongDegrees>, IComparable<LatLongDegrees>
    {
        public double Radius { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public LatLongDegrees(double radius, double latitude, double longitude) : this()
        {
            Longitude = longitude;
            Latitude = latitude;
            Radius = radius;
        }

        public static explicit operator LatLongDegrees(LatLongRadians radians)
        {
            return new LatLongDegrees(radians.Radius,
                MathEx.ToDegrees(radians.Latitude),
                MathEx.ToDegrees(radians.Longitude));
        }

        public override string ToString()
        {
            return string.Format("[{0:N4}, {1:N4}]", Latitude, Longitude);
        }

        #region Equality

        public bool Equals(LatLongDegrees other)
        {
            return other.Radius.Equals(Radius) && other.Latitude.Equals(Latitude) && other.Longitude.Equals(Longitude);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(obj.GetType() != typeof(LatLongDegrees))
            {
                return false;
            }
            return Equals((LatLongDegrees)obj);
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

        public static bool operator ==(LatLongDegrees left, LatLongDegrees right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LatLongDegrees left, LatLongDegrees right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(LatLongDegrees other)
        {
            return Equals(other) ? 0 : -1;
        }

        #endregion
    }
}
