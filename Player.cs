//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class with information about the player
    /// </summary>
    public class Player : IComparable
    {
        /// <summary>
        /// Name field
        /// </summary>
        private string name;

        /// <summary>
        /// Moves field
        /// </summary>
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
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets the moves
        /// </summary>
        public int Moves
        {
            get { return this.moves; }
            set { this.moves = value; }
        }

        /// <summary>
        /// Method to compare the moves of two players
        /// </summary>
        /// <param name="player">The player which we want to compare with</param>
        /// <returns>The result after the compare</returns>
        public int CompareTo(object player)
        {
            Player currentPlayer = (Player)player;
            int result = this.Moves.CompareTo(currentPlayer.Moves);
            return result;
        }
    }
}
