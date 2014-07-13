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
        public static void PrintMatrix(int[,] sourceMatrix)
        {
            Console.WriteLine(" -------------");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 4; j++)
                {
                    if (sourceMatrix[i, j] <= 9)
                    {
                        Console.Write("  {0}", sourceMatrix[i, j]);
                    }



                    else
                    {
                        if (sourceMatrix[i, j] == 16)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0}", sourceMatrix[i, j]);
                        }
                    }
                    if (j == 4 - 1)
                    {



                        Console.Write(" |\n");
                    }
                }
            }
            Console.WriteLine(" -------------");
        }

        /// <summary>
        /// The tiles movement logic
        /// </summary>
        /// <param name="tiles">The input list of tiles</param>
        /// <param name="number">The tile to be moved</param>
        /// <returns>The new matrix to be drawn</returns>
        public static int[,] MoveTiles(int[,] tiles, int number)
        {
            var resultMatrix = new int[4,4];
            if (number < 0 || number > 15)
            {
                throw new ArgumentException("Invalid move!");
            }

            bool isValid = false;
            int newRow = 0;
            int newCol = 0;
            for (int i = 0; i < 4; i++)
            {
                newRow = MatrixGenerator.emptyRow + MatrixGenerator.dirR[i];
                newCol = MatrixGenerator.emptyCol + MatrixGenerator.dirC[i];
                if (MatrixGenerator.IfOutOfMAtrix(newRow, newCol))
                {
                    continue;
                }
                if (MatrixGenerator.currentMatrix[newRow, newCol] == number)
                {
                    isValid = true;
                    MatrixGenerator.MoveEmptyCell(newRow, newCol);
                    //steps++;
                    resultMatrix = MatrixGenerator.currentMatrix;
                    break;
                }
                if (i == 3)
                {
                    isValid = false;
                }
            }


            if (!isValid)
            {
                Console.WriteLine("Invalid move");
            }

            return resultMatrix;

            //int[,] resultMatrix = tiles;
            //Tile freeTile = tiles[GetFreeTilePosition(tiles)];
            //Tile tile = tiles[GetDestinationTilePosition(tiles, number)];

            //bool areValidNeighbourTiles = ValidateTilePosition(freeTile, tile);

            //if (areValidNeighbourTiles)
            //{
            //    int targetTilePosition = tile.Position;
            //    resultMatrix[targetTilePosition].Position = freeTile.Position;
            //    resultMatrix[freeTile.Position].Position = targetTilePosition;
            //    resultMatrix.Sort();
            //}
            //else
            //{
            //    throw new Exception("Invalid move!");
            //}

        }

        /// <summary>
        /// A check whether the matrix is ordered and the game must end
        /// </summary>
        /// <param name="tiles">The list of tiles forming the matrix</param>
        /// <returns>The result whether the game must end or not</returns>
        public static bool CheckWhetherMatrixIsSolved(int[,] tiles)
        {
            int count = 1;

            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (tiles[i, j] != count)
                    {
                        return false;
                    }
                    count++;
                }
            }

            return true;
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
