//-----------------------------------------------------------------------
// <copyright file="IRandomNumberGenerator.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Contracts.Engine
{
    /// <summary>
    /// Random number generators interface
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        /// Provides the next random value without upper or lower limit
        /// </summary>
        /// <returns>A random value</returns>
        int Next();

        /// <summary>
        /// Provides the next random value with an upper limit only
        /// </summary>
        /// <param name="maxValue">Upper limit</param>
        /// <returns>A random value</returns>
        int Next(int maxValue);

        /// <summary>
        /// Provides the next random value with an upper and a lower limit
        /// </summary>
        /// <param name="minValue">Lower limit</param>
        /// <param name="maxValue">Upper limit</param>
        /// <returns>A random value</returns>
        int Next(int minValue, int maxValue);
    }
}