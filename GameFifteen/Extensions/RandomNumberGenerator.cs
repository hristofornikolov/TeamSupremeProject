namespace GameFifteenProject.Extensions
{
    using System;
    using GameFifteenProject.Contracts.Engine;

    /// <summary>
    /// Generates random numbers for the inintial rearrangement of the game field prior to game start.
    /// </summary>
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private static readonly Random generator = new Random();

        /// <summary>
        /// Provides the next random value without upper or lower limit
        /// </summary>
        /// <returns>A random value</returns>
        public int Next()
        {
            return this.Next(0, Int32.MaxValue - 1);
        }

        /// <summary>
        /// Provides the next random value with an upper limit only
        /// </summary>
        /// <param name="maxValue">Upper limit</param>
        /// <returns>A random value</returns>
        public int Next(int maxValue)
        {
            return this.Next(0, maxValue);
        }

        /// <summary>
        /// Provides the next random value with an upper and a lower limit
        /// </summary>
        /// <param name="minValue">Lower limit</param>
        /// <param name="maxValue">Upper limit</param>
        /// <returns>A random value</returns>
        public int Next(int minValue, int maxValue)
        {
            return generator.Next(minValue, maxValue + 1);
        }
    }
}