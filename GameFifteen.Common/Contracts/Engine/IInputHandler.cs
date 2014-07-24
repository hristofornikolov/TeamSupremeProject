//-----------------------------------------------------------------------
// <copyright file="IInputHandler.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Contracts.Engine
{
    /// <summary>
    /// Input readers interface
    /// </summary>
    public interface IInputHandler
    {
        /// <summary>
        /// Input reading method
        /// </summary>
        /// <returns>The input read</returns>
        string GetInput();
    }
}