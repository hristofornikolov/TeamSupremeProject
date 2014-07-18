//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Contracts.Engine
{
    /// <summary>
    /// Commands interface
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of a command
        /// </summary>
        string Name { get; }
    }
}