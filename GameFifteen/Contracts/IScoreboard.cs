//-----------------------------------------------------------------------
// <copyright file="IScoreboard.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Scoreboards interface
    /// </summary>
    public interface IScoreboard
    {      
        /// <summary>
        /// Gets the list of players to be displayed on the scoreboard
        /// </summary>
        IList<IPlayer> Players { get; }

        /// <summary>
        /// Adds a player to the list of players to be displayed on the scoreboard
        /// </summary>
        /// <param name="player">Current player which we want to add to the scoreboard</param>
        void AddPlayer(IPlayer player);
    }
}