﻿namespace GameFifteenProject.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    using GameFifteenProject.Contracts;
    using GameFifteenProject.Engine;

    public class ScoreboardProxy : IScoreboard
    {
        private Scoreboard realScoreboard;

        public void AddPlayer(Player player)
        {
            this.CheckIfScoreboardIsActive();
            
            if (this.realScoreboard.Players.Count > GameFifteenConstants.ScoreboardTopPlayersCount)
            {
                this.RemoveWorstPlayer();
            }

            this.realScoreboard.AddPlayer(player);
        }

        public IList<Player> Players
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