//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// Abstract class that defines specific commands
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// Abstract field of IGameEngine
        /// </summary>
        protected IGameEngine gameEngine;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="gameEngine">The specific GameEngine</param>
        protected Command(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        /// <summary>
        /// Abstract method to execute the given command
        /// </summary>
        /// <returns>commandResult string</returns>
        public abstract string Execute();
    }
}