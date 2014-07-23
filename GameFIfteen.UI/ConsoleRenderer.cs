//-----------------------------------------------------------------------
// <copyright file="ConsoleRenderer.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.UI
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// Defines the renderer
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Console reading method
        /// </summary>
        /// <returns>The input read</returns>
        public string Input()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Console writing method
        /// </summary>
        /// <param name="output">The output written</param>
        public void Output(string output)
        {
            Console.Write(output);
        }
    }
}