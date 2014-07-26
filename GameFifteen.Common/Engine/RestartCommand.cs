//-----------------------------------------------------------------------
// <copyright file="RestartCommand.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// A command for restaring the whole game
    /// </summary>
    public class RestartCommand : Command
    {
        public RestartCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        /// <summary>
        /// Restarts the whole game.
        /// </summary>
        /// <returns>Calls the Restart method of the GameEngine class.</returns>
        public override string Execute()
        {
            return this.gameEngine.Restart();
        }
    }
}