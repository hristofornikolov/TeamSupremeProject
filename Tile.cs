//-----------------------------------------------------------------------
// <copyright file="Tile.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class used to manage tiles
    /// </summary>
    public class Tile : IComparable
    {
        /// <summary>
        /// String showing the label of the tile
        /// </summary>
        private string label;

        /// <summary>
        /// Integer showing the position of the tile
        /// </summary>
        private int position;

        /// <summary>
        /// Initializes a new instance of the Tile class.
        /// </summary>
        public Tile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Tile class.
        /// </summary>
        /// <param name="label">Showing the label of the tile</param>
        /// <param name="position">Showing the position of the tile</param>
        public Tile(string label, int position)
        {
            this.Label = label;
            this.position = position;
        }

        /// <summary>
        /// Gets label of the tile.
        /// </summary>
        public string Label
        {
            get 
            { 
                return this.label;
            }
            private set
            {
                this.label = value;
            }
        }

        /// <summary>
        /// Gets or sets the position of the tile.
        /// </summary>
        public int Position
        {
            get 
            { 
                return this.position;
            }
            set 
            {
                this.position = value;
            }
        }

        /// <summary>
        /// Compares the positions of two tiles
        /// </summary>
        /// <param name="tile">Second tile</param>
        /// <returns>The tile with bigger position</returns>
        public int CompareTo(object tile)
        {
            Tile currentTile = (Tile)tile;
            int result = this.position.CompareTo(currentTile.Position);

            return result;
        }
    }
}
