//-----------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Contracts.Engine
{
    /// <summary>
    /// Renderers interface
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Input reading method
        /// </summary>
        /// <returns>The input read</returns>
        string Input();

        /// <summary>
        /// Output writing method
        /// </summary>
        /// <param name="result">The output written</param>
        void Output(string result);
    }
}