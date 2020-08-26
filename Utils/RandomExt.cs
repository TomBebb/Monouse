using System;

namespace Monuse.Utils
{
    public static class RandomExt
    {
        public static double Next(this Random rng, double min, double max)
            => min + rng.NextDouble() * (max - min);

        public static float Next(this Random rng, float min, float max)
            => (float) rng.Next((double) min, max);
    }
}