using System;

namespace BerlinClock.Helpers
{
    internal static class Args
    {
        public static void ThrowIfNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void ThrowIfOutOfRange<T>(T value, string parameterName, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, $"{parameterName ?? "Value"} is out of range.");
            }
        }
    }
}
