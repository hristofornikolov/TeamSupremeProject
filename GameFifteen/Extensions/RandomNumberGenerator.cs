namespace GameFifteenProject.Extensions
{
    using System;
    using GameFifteenProject.Contracts.Engine;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random generator = new Random();

        public int Next()
        {
            return this.Next(0, Int32.MaxValue - 1);
        }

        public int Next(int maxValue)
        {
            return this.Next(0, maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return generator.Next(minValue, maxValue + 1);
        }
    }
}