namespace GameFifteenProject.Extensions
{
    using System;

    public static class RandomNumberGenerator
    {
        private static readonly Random generator = new Random();

        public static int Next()
        {
            return Next(0, Int32.MaxValue - 1);
        }

        public static int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return generator.Next(minValue, maxValue + 1);
        }
    }
}
