using System;

namespace Monuse.Utils
{
    /// <summary>
    ///     Math extensions, intended for use in score calculus
    /// </summary>
    public static class MathExt
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                value = min;
            else if (value.CompareTo(max) > 0)
                value = max;

            return value;
        }

        public static double Clamp(double value, double min, double max)
        {
            return Clamp<double>(value, min, max);
        }

        public static float Clamp(float value, float min, float max)
        {
            return Clamp<float>(value, min, max);
        }
    }
}