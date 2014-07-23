//-----------------------------------------------------------------------
// <copyright file="GameFifteenEngine.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Engine
{
    using System;
    using System.Text;
    using GameFifteen.Contracts;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.GameObjects;
    using GameFifteen.Engine.Factories;

    public sealed class GameFifteenEngine : IGameEngine
    {
        // All possible directions for moving the cells
        private static readonly int[] dirRow = { -1, 0, 1, 0 };
        private static readonly int[] dirColumn = { 0, 1, 0, -1 };

        private readonly IFieldMatrix field;
        private readonly IRenderer renderer;
        private readonly IScoreboard scoreboard;
        private readonly IRandomNumberGenerator random;

        private int emptyCellRow;
        private int emptyCellColumn;
        private int emptyCellValue;
        private int movesCount;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameFifteenEngine"/> class from being created
        /// </summary>
        public GameFifteenEngine(
            IFieldMatrix field,
            IRenderer renderer,
            IScoreboard scoreboardProxy,
            IRandomNumberGenerator random)
        {
            this.field = field;
            this.renderer = renderer;
            this.scoreboard = scoreboardProxy;
            this.random = random;
        }

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
        private void ChangeEmptyCellPosition(int newRow, int newCol)
        {
            int swapValue = this.field[newRow, newCol];
            this.field[newRow, newCol] = this.emptyCellValue;
            this.field[this.emptyCellRow, this.emptyCellColumn] = swapValue;

            this.emptyCellRow = newRow;
            this.emptyCellColumn = newCol;
        }

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
        public string Restart()
        {
            this.InitializeField();
            this.movesCount = 0;

            var commandResult = new StringBuilder();
            commandResult.AppendLine();
            commandResult.AppendLine(this.ShowStartScreen());
            commandResult.AppendLine(this.ShowField());
            commandResult.Append(GameFifteenConstants.AskNumberMessage);
            return commandResult.ToString();
        }

        public string Exit()
        {
            return "exit";
        }

        public string Top()
        {
            return this.ShowScoreboard();
        }

        /// <summary>
        /// Moves the number provided by the command to the empty cell.
        /// </summary>
        /// <param name="newDestination">Destination cell</param>
        /// <returns>The redrawn matrix as a string</returns>
        public string MoveEmptyCell(string newDestination)
        {
            var commandResult = new StringBuilder();
            int nextDirection = this.GetNextDirection(newDestination);
            if (nextDirection == -1)
            {
                commandResult.AppendLine(GameFifteenConstants.InvalidCommandMessage);
                commandResult.AppendLine();
                commandResult.Append(GameFifteenConstants.AskNumberMessage);
                return commandResult.ToString();
            }

            int nextRow = this.emptyCellRow + dirRow[nextDirection];
            int nextCol = this.emptyCellColumn + dirColumn[nextDirection];
            this.ChangeEmptyCellPosition(nextRow, nextCol);
            this.movesCount++;

            if (this.CheckIfFieldIsSolved())
            {
                this.FinishGame();
                commandResult.Clear();
                commandResult.Append(this.Restart());
            }
            else
            {
                commandResult.AppendLine(this.ShowField());
                commandResult.Append(GameFifteenConstants.AskNumberMessage);
            }

            return commandResult.ToString();
        }

        /// <summary>
        /// Initializes the matrix and prepares it for the game by rearranging the field.
        /// </summary>
        public void InitializeField()
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
        public void RearrangeField()
        {
            int shuffles = this.random.Next(
                GameFifteenConstants.FieldMinimumShuffles, GameFifteenConstants.FieldMaximumShuffles);
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

                this.ChangeEmptyCellPosition(newRowIndex, newColIndex);
            }

            if (this.CheckIfFieldIsSolved())
            {
                this.RearrangeField();
            }
        }

        /// <summary>
        /// Draws/writes the starting screen description message.
        /// </summary>
        /// <returns>All the text of the starting screen</returns>
        public string ShowStartScreen()
        {
            var output = new StringBuilder();
            output.AppendLine(GameFifteenConstants.StartScreenMessage);
            output.AppendLine(GameFifteenConstants.CmdsDescriptionMessage);
            output.AppendLine(GameFifteenConstants.RestartCmdDescriptionMessage);
            output.AppendLine(GameFifteenConstants.TopCmdDescriptionMessage);
            output.AppendLine(GameFifteenConstants.ExitCmdDescriptionMessage);
            return output.ToString();
        }

        /// <summary>
        /// Returns the matrix itself.
        /// </summary>
        /// <returns>The matrix as a string</returns>
        public string ShowField()
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
        public string ShowScoreboard()
        {
            var output = new StringBuilder();
            output.AppendLine();
            output.AppendLine(GameFifteenConstants.ScoreboardTitle);

            var players = this.scoreboard.Players;
            if (players.Count == 0)
            {
                output.AppendLine("There aren't any records yet.");
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    output.AppendFormat(GameFifteenConstants.ScoreboardView, i + 1, players[i].Name, players[i].Moves);
                    output.AppendLine();
                }
            }

            output.AppendLine();
            output.Append(GameFifteenConstants.AskNumberMessage);
            return output.ToString();
        }

        /// <summary>
        /// Checks whether the game has come to a solution and proceeds to asking for the player's name.
        /// </summary>
        /// <returns>A boolean result whether to proceed to end or not</returns>
        public bool CheckIfFieldIsSolved()
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
        /// Ends the game and asks the player for his name.
        /// </summary>
        /// <returns>The desired command</returns>
        public void FinishGame()
        {
            this.renderer.Output(this.ShowField());
            this.renderer.Output(String.Format(GameFifteenConstants.WinMessage, this.movesCount));
            this.renderer.Output(Environment.NewLine);
            this.renderer.Output(GameFifteenConstants.AskNameMessage);

            string playerName = this.renderer.Input();
            this.SavePlayerScore(playerName, this.movesCount);
        }

        /// <summary>
        /// Saves the player's score
        /// </summary>
        /// <param name="playerName">Player's name</param>
        /// <param name="playerScore">Player's score</param>
        public void SavePlayerScore(string playerName, int playerScore)
        {
            IPlayer newPlayer = new Player(playerName, playerScore);
            this.scoreboard.AddPlayer(newPlayer);
        }
    }
}