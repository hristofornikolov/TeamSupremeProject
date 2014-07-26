//-----------------------------------------------------------------------
// <copyright file="IGameController.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//---------------------------------------------------------------------

namespace GameFifteen.Common.Contracts.Engine
{
    /// <summary>
    /// GameController interface
    /// </summary>
    public interface IGameController
    {
        /// <summary>
        /// Starts the game
        /// </summary>
        void Start();

        /// <summary>
        /// Executes a given string command
        /// </summary>
        /// <param name="input">User input as string from the console</param>
        /// <returns>Calls the execute method of the command</returns>
        string ExecuteCommand(string input);
    }
}
