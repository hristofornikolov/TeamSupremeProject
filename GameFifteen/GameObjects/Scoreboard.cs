//-----------------------------------------------------------------------
// <copyright file="IScoreboard.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using GameFifteen.Contracts;

    /// <summary>
    /// Display the scoreboard
    /// </summary>
    public class Scoreboard : IScoreboard
    {
        /// <summary>
        /// List with all players
        /// </summary>
        private readonly IList<IPlayer> players;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard"/> class
        /// </summary>
        public Scoreboard()
        {
            this.players = new List<IPlayer>();
        }

        /// <summary>
        /// Gets all players in the scoreboard sorted by their moves in ascending order
        /// </summary>
        public IList<IPlayer> Players
        {
            get
            {
                return this.players;
            }
        }

        /// <summary>
        /// Method to add players
        /// </summary>
        /// <param name="player">Current player which we want to add to the scoreboard</param>
        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
        }
    }
}