//-----------------------------------------------------------------------
// <copyright file="ExitCommand.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// A command type of class for exiting the game. Inherits the Command class
    /// </summary>
    public class ExitCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommand"/> class.
        /// </summary>
        /// <param name="gameEngine">The given instance of GameEngine</param>
        public ExitCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        /// <summary>
        /// Executes the exit command through the GameEngine
        /// </summary>
        /// <returns>Calls the Exit method of this GameEngine class</returns>
        public override string Execute()
        {
            return this.gameEngine.Exit();
        }
    }
}