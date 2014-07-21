//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Engine
{
    /// <summary>
    /// Abstract class that defines specific commands
    /// </summary>
    public abstract class Command
    {
        protected GameFifteenEngine gameEngine;

        protected Command(GameFifteenEngine gameEngine)
        {
            this.gameEngine = gameEngine;
        }

        public abstract string Execute();
    }
}