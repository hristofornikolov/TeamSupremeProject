//-----------------------------------------------------------------------
// <copyright file="GameFifteenEngine.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine
{
    using System;
    using System.Text;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common;
    using GameFifteen.Common.Engine.Factories;

    /// <summary>
    /// The current game engine
    /// </summary>
    public class GameFifteenEngine : IGameEngine
    {
        // All possible directions for moving the cells
        private static readonly int[] dirRow = { -1, 0, 1, 0 };
        private static readonly int[] dirColumn = { 0, 1, 0, -1 };

        private readonly IMatrixField field;
        private readonly IScoreboard scoreboard;
        private readonly IRandomNumberGenerator random;

        private int emptyCellRow;
        private int emptyCellColumn;
        private int emptyCellValue;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameFifteenEngine"/> class from being created
        /// </summary>
        public GameFifteenEngine(
            IMatrixField field,
            IScoreboard scoreboardProxy,
            IRandomNumberGenerator random)
        {
            this.field = field;
            this.scoreboard = scoreboardProxy;
            this.random = random;
        }

        public int PlayerMoves { get; private set; }

        /// <summary>
        /// Checks whether the number input by the user is inside the matrix by its coordinates.
        /// </summary>
        /// <param name="row">Current cell row</param>
        /// <param name="col">Current cell column</param>
        /// <returns>True or false</returns>
        private bool IsInsideField(int row, int col)
        {
            return 0 <= row && row < this.field.Rows &&
                   0 <= col && col < this.field.Columns;
        }

        /// <summary>
        /// Checks destination and returns the next direction
        /// </summary>
        /// <param name="destination">Destination cell</param>
        /// <returns>The next direction</returns>
        private int GetNextDirection(string destination)
        {
            int swapNumber;
            if (!int.TryParse(destination, out swapNumber))
            {
                return -1;
            }

            for (int i = 0; i < dirRow.Length; i++)
            {
                int nextRow = this.emptyCellRow + dirRow[i];
                int nextCol = this.emptyCellColumn + dirColumn[i];

                if (this.IsInsideField(nextRow, nextCol) &&
                    this.field[nextRow, nextCol] == swapNumber)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Moves the empty cell according to the number command provided by the user.
        /// </summary>
        /// <param name="newRow">Cell row</param>
        /// <param name="newCol">Cell column</param>
        private void SwаpEmptyCellPosition(int newRow, int newCol)
        {
            int swapValue = this.field[newRow, newCol];
            this.field[newRow, newCol] = this.emptyCellValue;
            this.field[this.emptyCellRow, this.emptyCellColumn] = swapValue;

            this.emptyCellRow = newRow;
            this.emptyCellColumn = newCol;
        }

        /// <summary>
        /// Returns the string representation of a digit
        /// </summary>
        /// <param name="number">An integer between 0 and 9.</param>
        /// <returns>The string representation of the digit</returns>
        private string GetNumberAsString(int number)
        {
            if (number == this.emptyCellValue)
            {
                return string.Empty;
            }

            var numberAsString = new StringBuilder();
            foreach (var digit in number.ToString())
            {
                numberAsString.Append(NumberFactory.Instance.GetDigit(digit));
            }

            return numberAsString.ToString();
        }

        /// <summary>
        /// Restarts the game and initializes the field.
        /// </summary>
        /// <returns>The string representation of the resulting command.</returns>
        public virtual string Restart()
        {
            this.InitializeField();
            this.PlayerMoves = 0;

            var commandResult = new StringBuilder();
            commandResult.AppendLine();
            commandResult.AppendLine(this.GetStartScreen());
            commandResult.AppendLine(this.GetField());
            commandResult.Append(GlobalConstants.AskNumberMessage);
            return commandResult.ToString();
        }

        /// <summary>
        /// Displays the Exit message.
        /// </summary>
        /// <returns>Displays the exit message.</returns>
        public virtual string Exit()
        {
            return GlobalConstants.ExitMessage;
        }

        /// <summary>
        /// Display the scoreboard
        /// </summary>
        /// <returns>Calls the GetScoreboard method</returns>
        public virtual string Top()
        {
            return this.GetScoreboard();
        }

        /// <summary>
        /// Moves the number provided by the command to the empty cell.
        /// </summary>
        /// <param name="newDestination">Destination cell</param>
        /// <returns>The redrawn matrix as a string</returns>
        public virtual string MoveEmptyCell(string newDestination)
        {
            var commandResult = new StringBuilder();
            int nextDirection = this.GetNextDirection(newDestination);
            if (nextDirection == -1)
            {
                commandResult.AppendLine(GlobalConstants.InvalidCommandMessage);
                commandResult.AppendLine();
                commandResult.Append(GlobalConstants.AskNumberMessage);
                return commandResult.ToString();
            }

            int nextRow = this.emptyCellRow + dirRow[nextDirection];
            int nextCol = this.emptyCellColumn + dirColumn[nextDirection];
            this.SwаpEmptyCellPosition(nextRow, nextCol);
            this.PlayerMoves++;

            if (!this.IsFieldArrange())
            {
                commandResult.AppendLine(this.GetField());
                commandResult.Append(GlobalConstants.AskNumberMessage);
            }

            return commandResult.ToString();
        }

        /// <summary>
        /// Initializes the matrix and prepares it for the game by rearranging the field.
        /// </summary>
        public virtual void InitializeField()
        {
            int fillValue = 1;
            for (int i = 0; i < this.field.Length; i++)
            {
                this.field[i] = fillValue;
                fillValue++;
            }

            this.emptyCellRow = this.field.Rows - 1;
            this.emptyCellColumn = this.field.Columns - 1;
            this.emptyCellValue = this.field.Rows * this.field.Columns;

            this.RearrangeField();
        }

        /// <summary>
        /// Randomly rearranges the field to prepare it for the game start.
        /// </summary>
        public virtual void RearrangeField()
        {
            int shuffles = this.random.Next(
                GlobalConstants.FieldMinimumShuffles, GlobalConstants.FieldMaximumShuffles);
            for (int i = 0; i < shuffles; i++)
            {
                int randomDirectionIndex = this.random.Next(dirRow.Length - 1);
                int newRowIndex = this.emptyCellRow + dirRow[randomDirectionIndex];
                int newColIndex = this.emptyCellColumn + dirColumn[randomDirectionIndex];

                if (!this.IsInsideField(newRowIndex, newColIndex))
                {
                    // step back
                    i--;
                    continue;
                }

                this.SwаpEmptyCellPosition(newRowIndex, newColIndex);
            }

            if (this.IsFieldArrange())
            {
                this.RearrangeField();
            }
        }

        /// <summary>
        /// Draws/writes the starting screen description message.
        /// </summary>
        /// <returns>All the text of the starting screen</returns>
        public virtual string GetStartScreen()
        {
            var output = new StringBuilder();
            output.AppendLine(GlobalConstants.StartScreenMessage);
            output.AppendLine(GlobalConstants.CmdsDescriptionMessage);
            output.AppendLine(GlobalConstants.RestartCmdDescriptionMessage);
            output.AppendLine(GlobalConstants.TopCmdDescriptionMessage);
            output.AppendLine(GlobalConstants.ExitCmdDescriptionMessage);
            return output.ToString();
        }

        /// <summary>
        /// Returns the matrix itself.
        /// </summary>
        /// <returns>The matrix as a string</returns>
        public virtual string GetField()
        {
            var output = new StringBuilder();
            output.AppendLine(" -------------");

            for (int i = 0; i < this.field.Rows; i++)
            {
                output.Append("|");
                for (int j = 0; j < this.field.Columns; j++)
                {
                    var numberAsString = GetNumberAsString(this.field[i, j]);
                    output.AppendFormat("{0,3}", numberAsString);

                    if (j == this.field.Columns - 1)
                    {
                        output.AppendLine(" |");
                    }
                }
            }

            output.AppendLine(" -------------");
            return output.ToString();
        }

        /// <summary>
        /// Creates the scoreboard and shows it upon game end.
        /// </summary>
        /// <returns>The scoreboard as a string</returns>
        public virtual string GetScoreboard()
        {
            var output = new StringBuilder();
            output.AppendLine();
            output.AppendLine(GlobalConstants.ScoreboardTitle);

            var players = this.scoreboard.Players;
            if (players.Count == 0)
            {
                output.AppendLine("There aren't any records yet.");
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    output.AppendFormat(GlobalConstants.ScoreboardView, i + 1, players[i].Name, players[i].Moves);
                    output.AppendLine();
                }
            }

            output.AppendLine();
            output.Append(GlobalConstants.AskNumberMessage);
            return output.ToString();
        }

        /// <summary>
        /// Checks whether the game has come to a solution and proceeds to asking for the player's name.
        /// </summary>
        /// <returns>A boolean result whether to proceed to end or not</returns>
        public virtual bool IsFieldArrange()
        {
            int firstCellValue = 1;

            foreach (var num in this.field)
            {
                if (num != firstCellValue)
                {
                    return false;
                }

                firstCellValue++;
            }

            return true;
        }

        /// <summary>
        /// Saves the player's score
        /// </summary>
        /// <param name="playerName">Player's name</param>
        /// <param name="playerScore">Player's score</param>
        public virtual void SavePlayerScore(string playerName, int playerScore)
        {
            IPlayer newPlayer = new Player(playerName, playerScore);
            this.scoreboard.AddPlayer(newPlayer);
        }
    }
}