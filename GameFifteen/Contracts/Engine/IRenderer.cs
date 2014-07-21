//-----------------------------------------------------------------------
// <copyright file="IRenderer.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Contracts.Engine
{
    /// <summary>
    /// Renderers interface
    /// </summary>
    public interface IRenderer
    {
        /// <summary>
        /// Console reading method
        /// </summary>
        /// <returns>The input read</returns>
        string Input();

        /// <summary>
        /// Console writing method
        /// </summary>
        /// <param name="output">The output written</param>
        void Output(string output);
    }
}