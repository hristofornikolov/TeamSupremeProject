//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.GameObjects
{
    /// <summary>
    /// Class with information about the player
    /// </summary>
    public class Player
    {
        private const string UnknownName = "Unknown";

        private string name;

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
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "Unknown";
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the moves of the <see cref="Player"/> class instance
        /// </summary>
        public int Moves { get; set; }
    }
}
