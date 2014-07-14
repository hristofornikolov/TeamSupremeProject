//-----------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using GameFifteenProject.Engine;

    /// <summary>
    /// Display the scoreboard
    /// </summary>
    public class Scoreboard
    {

        /// <summary>
        /// List with all players
        /// </summary>
        private static IList<Player> players;

        public Scoreboard()
        {
            players = new List<Player>();
        }

        /// <summary>
        /// Method to add players
        /// </summary>
        /// <param name="player">Current player which we want to add to the scoreboard</param>
        public void AddPlayer(Player player)
        {
            players.Add(player);

            if (players.Count > GameFifteenConstants.ScoreboardTopPlayersCount)
            {
                RemoveWorstPlayer();
            }
        }

        /// <summary>
        /// Get all players in the scoreboard
        /// sorted by their moves in ascending order
        /// </summary>
        public IList<Player> Players
        {
            get
            {
                return players
                    .OrderBy(p => p.Moves)
                    .ToList();
            }
        }

        /// <summary>
        /// Method which removes the worst player
        /// </summary>
        private static void RemoveWorstPlayer()
        {
            var worstPlayer = players
                .OrderByDescending(p => p.Moves)
                .First();

            players.Remove(worstPlayer);
        }
    }
}
