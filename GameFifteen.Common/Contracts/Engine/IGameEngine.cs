//-----------------------------------------------------------------------
// <copyright file="IGameEngine.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//--------------------------------------------------------------------

namespace GameFifteen.Common.Contracts.Engine
{
    using System;

    /// <summary>
    /// GameEngine interface
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Gets player moves count
        /// </summary>
        int PlayerMoves { get; }

        /// <summary>
        /// Restarts the game and initializes the field
        /// </summary>
        /// <returns>commandResult string</returns>
        string Restart();

        /// <summary>
        /// Displays exit message on the console
        /// </summary>
        /// <returns>Exit message</returns>
        string Exit();

        /// <summary>
        /// Displays the scoreboard
        /// </summary>
        /// <returns>The scoreboard</returns>
        string Top();

        /// <summary>
        /// Moves the number provided by the command to the empty cell.
        /// </summary>
        /// <param name="newDestination">Destination cell</param>
        /// <returns>The redrawn matrix as a string</returns>
        string MoveEmptyCell(string newDestination);

        /// <summary>
        /// Initializes the matrix and prepares it for the game by rearranging the field.
        /// </summary>
        void InitializeField();

        /// <summary>
        /// Randomly rearranges the field to prepare it for the game start.
        /// </summary>
        void RearrangeField();

        /// <summary>
        /// Draws/writes the starting screen description message.
        /// </summary>
        /// <returns>All the text of the starting screen</returns>
        string GetStartScreen();

        /// <summary>
        /// Returns the matrix itself.
        /// </summary>
        /// <returns>The matrix as a string</returns>
        string GetField();

        /// <summary>
        /// Creates the scoreboard and shows it upon game end.
        /// </summary>
        /// <returns>The scoreboard as a string</returns>
        string GetScoreboard();

        /// <summary>
        /// Ends the game and asks the player for his name.
        /// </summary>
        /// <returns>The desired command</returns>
        bool IsFieldArrange();

        /// <summary>
        /// Saves the player's score
        /// </summary>
        /// <param name="playerName">Player's name</param>
        /// <param name="playerScore">Player's score</param>
        void SavePlayerScore(string playerName, int playerScore);
    }
}