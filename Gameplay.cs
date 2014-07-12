//-----------------------------------------------------------------------
// <copyright file="Gameplay.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is the movement logic arranged in the Gameplay class
    /// </summary>
    public static class Gameplay
    {
        /// <summary>
        /// A constant to assist us in measuring the horizontal distance between two tiles
        /// </summary>
        private const int HorizontalNeighbourTile = 1;

        /// <summary>
        /// A constant to assist us in measuring the vertical distance between two tiles
        /// </summary>
        private const int VerticalNeighbourTile = 4;

        /// <summary>
        /// The predefined matrix size
        /// </summary>
        private const int MatrixSize = 4;

        /// <summary>
        /// This is how we print the matrix
        /// </summary>
        /// <param name="sourceMatrix">This is the initial matrix (the matrix drawn before a move)</param>
        public static void PrintMatrix(List<Tile> sourceMatrix)
        {
            Console.WriteLine("  ------------");
            Console.Write("| ");
            int rowCounter = 0;
            for (int index = 0; index < 16; index++)
            {
                Tile currentElement = sourceMatrix.ElementAt(index);
                
                if (currentElement.Label == string.Empty)
                {
                    Console.Write("   ");
                }
                else if (int.Parse(currentElement.Label) < 10)
                {
                    Console.Write(' ' + currentElement.Label + ' ');
                }
                else
                {
                    Console.Write(currentElement.Label + ' ');
                }

                rowCounter++;
                if (rowCounter == 4)
                {
                    Console.Write(" |");
                    Console.WriteLine();
                    if (index < 12)
                    {
                        Console.Write("| ");
                    }

                    rowCounter = 0;
                }
            }

            Console.WriteLine("  ------------");
        }

        /// <summary>
        /// The tiles movement logic
        /// </summary>
        /// <param name="tiles">The input list of tiles</param>
        /// <param name="tileValue">The tile to be moved</param>
        /// <returns>The new matrix to be drawn</returns>
        public static List<Tile> MoveTiles(List<Tile> tiles, int tileValue)
        {
            if (tileValue < 0 || tileValue > 15)
            {
                throw new ArgumentException("Invalid move!");
            }

            List<Tile> resultMatrix = tiles;
            Tile freeTile = tiles[GetFreeTilePosition(tiles)];
            Tile tile = tiles[GetDestinationTilePosition(tiles, tileValue)];

            bool areValidNeighbourTiles = ValidateTilePosition(freeTile, tile);

            if (areValidNeighbourTiles)
            {
                int targetTilePosition = tile.Position;
                resultMatrix[targetTilePosition].Position = freeTile.Position;
                resultMatrix[freeTile.Position].Position = targetTilePosition;
                resultMatrix.Sort();
            }
            else
            {
                throw new Exception("Invalid move!");
            }

            return resultMatrix;
        }

        /// <summary>
        /// A check whether the matrix is ordered and the game must end
        /// </summary>
        /// <param name="tiles">The list of tiles forming the matrix</param>
        /// <returns>The result whether the game must end or not</returns>
        public static bool CheckWhetherMatrixIsSolved(List<Tile> tiles)
        {
            int count = 0;
            foreach (Tile tile in tiles)
            {
                int tileLabelInt = 0;
                int.TryParse(tile.Label, out tileLabelInt);
                if (tileLabelInt == (tile.Position + 1))
                {
                    count++;
                }
            }

            if (count == 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Getting the new tile position
        /// </summary>
        /// <param name="tiles">The list of tiles forming the matrix</param>
        /// <param name="tileValue">The tile to be moved</param>
        /// <returns>The new index for the tile to be moved to</returns>
        private static int GetDestinationTilePosition(List<Tile> tiles, int tileValue)
        {
            int result = 0;
            for (int index = 0; index < tiles.Count; index++)
            {
                int parsedLabel = 0;
                bool successfulParsing = int.TryParse(tiles[index].Label, out parsedLabel);
                if (successfulParsing && tileValue == parsedLabel)
                {
                    result = index;
                }
            }

            return result;
        }

        /// <summary>
        /// Validation of the new tile position
        /// </summary>
        /// <param name="freeTile">The new tile position to be checked</param>
        /// <param name="tile">The current tile we are comparing</param>
        /// <returns>Valid or not</returns>
        private static bool ValidateTilePosition(Tile freeTile, Tile tile)
        {
            bool areValidNeighbourTiles = CheckNeighbourTilesValidity(freeTile, tile);

            return areValidNeighbourTiles;
        }

        /// <summary>
        /// Validation of the neighboring tile
        /// </summary>
        /// <param name="freeTile">The new tile position to be checked</param>
        /// <param name="tile">The current tile we are comparing</param>
        /// <returns>Is neighbor valid or not</returns>
        private static bool CheckNeighbourTilesValidity(Tile freeTile, Tile tile)
        {
            int tilesDistance = freeTile.Position - tile.Position;
            int tilesAbsoluteDistance = Math.Abs(tilesDistance);
            bool isValidHorizontalNeighbour =
                tilesAbsoluteDistance == HorizontalNeighbourTile && !(((tile.Position + 1) % MatrixSize == 1 && tilesDistance == -1) || ((tile.Position + 1) % MatrixSize == 0 && tilesDistance == 1));
            bool isValidVerticalNeighbour = tilesAbsoluteDistance == VerticalNeighbourTile;
            bool validNeigbour = isValidHorizontalNeighbour || isValidVerticalNeighbour;

            return validNeigbour;
        }

        /// <summary>
        /// Getting the position of the free tile to which we move our tile
        /// </summary>
        /// <param name="tiles">The list of tiles forming the matrix</param>
        /// <returns>The new position</returns>
        private static int GetFreeTilePosition(List<Tile> tiles)
        {
            int result = 0;
            for (int index = 0; index < tiles.Count; index++)
            {
                if (tiles[index].Label == string.Empty)
                {
                    result = index;
                }
            }

            return result;
        }
    }
}
