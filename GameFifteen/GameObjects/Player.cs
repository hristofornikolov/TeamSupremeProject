//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.GameObjects
{
    using System;

    using GameFifteenProject.Engine;

    /// <summary>
    /// Class with information about the player
    /// </summary>
    internal class Player
    {
        private string name;
        private int moves;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="moves">Number of moves</param>
        public Player(string name, int moves)
        {
            this.Name = name;
            this.Moves = moves;
        }

        /// <summary>
        /// Gets or sets the name of the <see cref="Player"/> class instance
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = GameFifteenConstants.PlayerUnknownName;
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the moves of the <see cref="Player"/> class instance
        /// </summary>
        public int Moves 
        { 
            get
            {
                return this.moves;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Invalid player moves. It should not be possible for a player to win in less than one move.");
                }

                this.moves = value;
            }
        }
    }
}
