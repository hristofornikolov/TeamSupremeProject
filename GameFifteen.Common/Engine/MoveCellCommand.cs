//-----------------------------------------------------------------------
// <copyright file="MoveCellCommand.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

    /// <summary>
    /// A command for moving a cell in a specific destination
    /// </summary>
    public class MoveCellCommand : Command
    {
        public MoveCellCommand(IGameEngine gameEngine, string destination) : base(gameEngine)
        {
            this.Destination = destination;
        }

        public string Destination { get; set; }

        /// <summary>
        /// Executes the move command to the specific destination.
        /// </summary>
        /// <returns>Calls the MoveEmptyCell method of the GameEngine.</returns>
        public override string Execute()
        {
            return this.gameEngine.MoveEmptyCell(this.Destination);
        }
    }
}