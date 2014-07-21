//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.GameObjects
{
    using System;
    using GameFifteen.Contracts;
    using GameFifteen.Engine;

    /// <summary>
    /// Class with information about the player
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Field with the name of the Player
        /// </summary>
        private string name;

        /// <summary>
        /// Field with the moves of the Player
        /// </summary>
        private int moves;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class
        /// </summary>
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

            set
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

            set
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