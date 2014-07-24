//-----------------------------------------------------------------------
// <copyright file="InputHandler.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.UI
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// Defines the input handler
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InputHandler : IInputHandler
    {
        /// <summary>
        /// Input reading method
        /// </summary>
        /// <returns>The input read</returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}