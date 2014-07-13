//-----------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Display the scoreboard
    /// </summary>
    public static class Scoreboard
    {
        /// <summary>
        /// List with all players
        /// </summary>
        private static readonly List<Player> Players = new List<Player>();

        /// <summary>
        /// Method to add players
        /// </summary>
        /// <param name="player">Current player which we want to add to the scoreboard</param>
        public static void AddPlayer(Player player)
        {
            Players.Add(player);
            Players.Sort();
            DeleteAllExceptTopPlayers();
        }
        
        /// <summary>
        /// Method to display all players in the scoreboard
        /// </summary>
        public static void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard:");
            foreach (Player player in Players)
            {
                string scoreboardLine = (Players.IndexOf(player) + 1).ToString() + ". " + player.Name + " --> " + player.Moves.ToString() + " moves";
                Console.WriteLine(scoreboardLine);
            }
        }

        /// <summary>
        /// Method to delete players
        /// </summary>
        private static void DeleteAllExceptTopPlayers()
        {
            for (int index = 0; index < Players.Count(); index++)
            {
                if (index > 4)
                {
                    Players.Remove(Players[index]);
                }
            }
        }
    }
}
