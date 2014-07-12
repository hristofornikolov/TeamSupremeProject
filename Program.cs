//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This is the engine of our game.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is how we start a game.
        /// </summary>
        public static void Main()
        {
            Menu();
        }

        /// <summary>
        /// This is the menu initialization.
        /// </summary>
        private static void Menu()
        {
            List<Tile> tiles = new List<Tile>();
            int stepsCount = 0;
            string input = "restart";
            bool doesGameEnd = false;

            while (input != "exit")
            {
                if (!doesGameEnd)
                {
                    switch (input)
                    {
                        case "restart":
                            {
                                string welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially. ";
                                welcomeMessage = welcomeMessage + "\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'exit'";
                                welcomeMessage = welcomeMessage + " \nto quit the game.";
                                Console.WriteLine();
                                Console.WriteLine(welcomeMessage);
                                tiles = MatrixGenerator.GenerateMatrix();
                                tiles = MatrixGenerator.ShuffleMatrix(tiles);
                                doesGameEnd = Gameplay.IsMatrixSolved(tiles);
                                Gameplay.PrintMatrix(tiles);
                                break;
                            }

                        case "top":
                            {
                                Scoreboard.PrintScoreboard();
                                break;
                            }
                    }

                    if (!doesGameEnd)
                    {
                        Console.Write("Enter a number to move: ");
                        input = Console.ReadLine();

                        int destinationTileValue;

                        bool isSuccessfulParsing = int.TryParse(input, out destinationTileValue);

                        if (isSuccessfulParsing)
                        {
                            try
                            {
                                Gameplay.MoveTiles(tiles, destinationTileValue);
                                stepsCount++;
                                Gameplay.PrintMatrix(tiles);
                                doesGameEnd = Gameplay.IsMatrixSolved(tiles);
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                input = Command.CommandType(input);
                            }
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                    }
                }
                else
                {
                    if (stepsCount == 0)
                    {
                        Console.WriteLine("Your matrix was solved by default :) Come on - NEXT try");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You won the game in {0} moves.", stepsCount);
                        Console.Write("Please enter your name for the top scoreboard: ");
                        string playerName = Console.ReadLine();
                        Player player = new Player(playerName, stepsCount);
                        Scoreboard.AddPlayer(player);
                        Scoreboard.PrintScoreboard();
                    }

                    input = "restart";
                    doesGameEnd = false;
                    stepsCount = 0;
                }
            }
        }
    }
}
