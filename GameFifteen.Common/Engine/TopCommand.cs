//-----------------------------------------------------------------------
// <copyright file="TopCommand.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// A command for displaying the scoreboard
    /// </summary>
    public class TopCommand : Command
    {
        public TopCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        /// <summary>
        /// Displays the scoreboard.
        /// </summary>
        /// <returns>Calls the Top method of the GameEngine class.</returns>
        public override string Execute()
        {
            return this.gameEngine.Top();
        }
    }
}