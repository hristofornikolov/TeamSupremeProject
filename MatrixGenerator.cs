//-----------------------------------------------------------------------
// <copyright file="MatrixGenerator.cs" company="TeamSupreme">
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
    /// Class used to generate matrix at the start
    /// and in the process of the game
    /// </summary>
    public static class MatrixGenerator
    {
        /// <summary>
        /// Constant used to correctly fill the matrix
        /// </summary>        
        private const int HorizontalNeighbourTile = 1;
        
        /// <summary>
        /// Constant used to correctly fill the matrix
        /// </summary>       
        private const int VerticalNeighbourTile = 4;

        /// <summary>
        /// Constant showing the size of the matrix
        /// </summary>
        private const int MatrixSize = 4;

        /// <summary>
        /// Constant showing the minimum possible count of cycles
        /// </summary>
        private const int MinimumCycles = 20;

        /// <summary>
        /// Constant showing the maximum possible count of cycles
        /// </summary>
        private const int MaximumCycles = 50;
        
        /// <summary>
        /// Random number
        /// </summary>
        private static Random random;

        /// <summary>
        /// Method that generates matrix
        /// </summary>
        /// <returns>
        /// List of Tile objects
        /// </returns>
        public static List<Tile> GenerateMatrix()
        {
            List<Tile> tiles = new List<Tile>();

            for (int index = 0; index < 15; index++)
            {
                string tileName = (index + 1).ToString();

                Tile tempTile = new Tile(tileName, index);
                tiles.Add(tempTile);
            }

            Tile emptyTile = new Tile(string.Empty, 15);
            tiles.Add(emptyTile);

            return tiles;
        }

        /// <summary>
        /// Method that shuffles matrix
        /// </summary>
        /// <returns>
        /// List of Tile objects
        /// </returns>
        /// <param name="startingMatrix">
        /// The starting matrix
        /// </param>
        public static List<Tile> ShuffleMatrix(List<Tile> startingMatrix)
        {
            random = new Random();
            int cycleCount = random.Next(MinimumCycles, MaximumCycles);
            List<Tile> resultMatrix = new List<Tile>();
            resultMatrix = startingMatrix;

            for (int index = 0; index < cycleCount; index++)
            {
                resultMatrix = MoveFreeTile(resultMatrix);
            }

            return resultMatrix;
        }

        /// <summary>
        /// Method that moves the free tile
        /// </summary>
        /// <returns>
        /// List of Tile objects after the free tiled is moved
        /// </returns>
        /// <param name="resultMatrix">
        /// The current matrix
        /// </param>
        private static List<Tile> MoveFreeTile(List<Tile> resultMatrix)
        {
            Tile freeTile = DetermineFreeTile(resultMatrix);

            List<Tile> neighbourTiles = new List<Tile>();

            foreach (Tile tile in resultMatrix)
            {
                neighbourTiles = GenerateNeighbourTilesList(freeTile, tile, neighbourTiles);
            }

            int switchedindexNumber = random.Next() % neighbourTiles.Count();
            Tile targetTile = neighbourTiles[switchedindexNumber];

            int targetTilePosition = targetTile.Position;
            resultMatrix[targetTile.Position].Position = freeTile.Position;
            resultMatrix[freeTile.Position].Position = targetTilePosition;
            resultMatrix.Sort();

            return resultMatrix;
        }

        /// <summary>
        /// Method that determines the free tile
        /// </summary>
        /// <returns>
        /// Tile object - the free tile
        /// </returns>
        /// <param name="resultMatrix">
        /// The current matrix        
        /// </param>
        private static Tile DetermineFreeTile(List<Tile> resultMatrix)
        {
            Tile freeTile = new Tile();

            foreach (Tile tile in resultMatrix)
            {
                if (tile.Label == string.Empty)
                {
                    freeTile = tile;
                }
            }

            return freeTile;
        }

        /// <summary>
        /// Method that generates list of neighbors
        /// </summary>
        /// <returns>
        /// List of Tile objects - neighbors of the free tile
        /// </returns>
        /// <param name="freeTile">
        /// The only free tile
        /// </param>        
        /// <param name="tile">
        /// The tile which neighbors we want to find
        /// </param>
        /// <param name="neighbourTiles">
        /// List of neighbor tiles
        /// </param>
        private static List<Tile> GenerateNeighbourTilesList(Tile freeTile, Tile tile, List<Tile> neighbourTiles)
        {
            bool areValidNeighbourTiles = AreValidNeighbourTiles(freeTile, tile);
            if (areValidNeighbourTiles)
            {
                neighbourTiles.Add(tile);
            }

            return neighbourTiles;
        }

        /// <summary>
        /// Method that checks whether a tile is
        /// valid neighbor of the free tile
        /// </summary>
        /// <returns>
        /// True or false whether the tile is
        /// valid or not
        /// </returns>
        /// <param name="freeTile">
        /// The only free tile
        /// </param>
        /// <param name="tile">
        /// The tile we want to check whether is valid or not
        /// </param>
        private static bool AreValidNeighbourTiles(Tile freeTile, Tile tile)
        {
            int tilesDistance = freeTile.Position - tile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool isValidHorizontalNeighbour =
                       tilesAbsoluteDistance == HorizontalNeighbourTile && 
                !((tile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) && 
                !((tile.Position + 1) % MatrixSize == 0 && tilesDistance == 1);
            bool isValidVerticalNeighbour = tilesAbsoluteDistance == VerticalNeighbourTile;
            bool validNeighbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeighbour;
        }
    }
}
