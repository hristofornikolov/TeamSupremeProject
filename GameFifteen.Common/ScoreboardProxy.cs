﻿//-----------------------------------------------------------------------
// <copyright file="ScoreboardProxy.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Engine;

    /// <summary>
    /// Class ScoreboardProxy - Implements the Proxy design pattern
    /// </summary>
    public class ScoreboardProxy : IScoreboard
    {
        /// <summary>
        /// Field with the real scoreboard
        /// </summary>
        private Scoreboard realScoreboard;

        /// <summary>
        /// Gets the ordered scoreboard with the best players
        /// </summary>
        public IList<IPlayer> Players
        {
            get
            {
                this.CheckIfScoreboardIsActive();

                if (this.realScoreboard.Players.Count > 0)
                {
                    return this.realScoreboard.Players
                               .OrderBy(p => p.Moves)
                               .ToList();
                }

                return this.realScoreboard.Players;
            }
        }

        /// <summary>
        /// Adds player to the scoreboard
        /// </summary>
        /// <param name="player">The player which we want to add to the scoreboard</param>
        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Scoreboard player cannot be null.");
            }

            this.CheckIfScoreboardIsActive();       

            this.realScoreboard.AddPlayer(player);
            if (this.realScoreboard.Players.Count > GlobalConstants.ScoreboardTopPlayersCount)
            {
                this.RemoveWorstPlayer();
            }
        }

        /// <summary>
        /// Check if the scoreboard is created
        /// </summary>
        private void CheckIfScoreboardIsActive()
        {
            if (this.realScoreboard == null)
            {
                this.realScoreboard = new Scoreboard();
            }
        }

        /// <summary>
        /// Method which removes the worst player
        /// </summary>
        private void RemoveWorstPlayer()
        {
            var worstPlayer = this.realScoreboard.Players
                                  .OrderByDescending(p => p.Moves)
                                  .First();

            this.realScoreboard.Players.Remove(worstPlayer);
        }
    }
}