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
        protected IGameEngine gameEngine;

        protected Command(IGameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public abstract string Execute();
    }
}