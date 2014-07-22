//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Engine
{
    using GameFifteen.Contracts.Engine;

    /// <summary>
    /// Abstract class that defines specific commands
    /// </summary>
    public abstract class Command
    {
        protected IGameEngine gameEngine;

        protected Command(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public abstract string Execute();
    }
}