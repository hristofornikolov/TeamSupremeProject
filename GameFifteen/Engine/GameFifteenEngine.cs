//-----------------------------------------------------------------------
// <copyright file="GameFifteenEngine.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Engine
{
    using System.Text;
    using GameFifteen.Contracts;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.GameObjects;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.Engine;
    using GameFifteen.Extensions;
    using GameFifteen.GameObjects;
    
    public sealed class GameFifteenEngine
    {       
        // All possible directions for moving the cells
        private static readonly int[] DirRow = { -1, 0, 1, 0 };
        private static readonly int[] DirColumn = { 0, 1, 0, -1 };

        private static GameFifteenEngine instance;

        private readonly FieldMatrix field;
        private readonly IRenderer renderer;
        private readonly IScoreboard scoreboard;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        private int emptyCellRow;
        private int emptyCellColumn;
        private int emptyCellValue;
        private int movesCount;

        /// <summary>
        /// Prevents a default instance of the <see cref="GameFifteenEngine"/> class from being created
        /// </summary>
        private GameFifteenEngine()
        {
            this.field = new FieldMatrix();
            this.renderer = new ConsoleRenderer();
            this.scoreboard = new ScoreboardProxy();
            this.randomNumberGenerator = new RandomNumberGenerator();
        }

        /// <summary>
        /// Gets a new instance of the game in case it has not been initialized.
        /// </summary>
        public static GameFifteenEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameFifteenEngine();
                }

                return instance;
            }
        }

        /// <summary>
        /// Restarts the game when the right command has been typed by the user.
        /// </summary>
        public void Start()
        {
            ICommand command = Command.Parse("restart");
            while (command.Name != "exit")
            {
                string commandResult = this.ProcessCommand(command);
                this.RenderCommandResult(commandResult);
                command = this.ReadCommand();

                if (this.CheckIfFieldIsSolved())
                {
                    command = this.EndGame(command);
                }
            }
        }

        /// <summary>
        /// Reads the command input
        /// </summary>
        /// <returns>The command that corresponds to the input provided.</returns>
        private ICommand ReadCommand()
        {
            var input = this.renderer.Input();
            var command = Command.Parse(input);

            return command;
        }
        
        /// <summary>
        /// Command processor based on the input provided by the user.
        /// </summary>
        /// <param name="command">User input</param>
        /// <returns>The desired command in a string form</returns>
        private string ProcessCommand(ICommand command)
        {
            StringBuilder commandResult = new StringBuilder();
            var action = command.Name.ToLower();
            switch (action)
            {
                case "restart":
                    this.Initialize();
                    commandResult.AppendLine();
                    commandResult.AppendLine(this.ShowStartScreen());
                    commandResult.AppendLine(this.ShowField());
                    break;
                case "exit":
                    commandResult.AppendLine(command.Name);
                    break;
                case "top":
                    commandResult.AppendLine(this.ShowScoreboard());
                    break;
                default:
                    commandResult.AppendLine(this.Move(action));
                    break;
            }

            if (this.CheckIfFieldIsSolved())
            {
                commandResult.AppendFormat(GameFifteenConstants.WinMessage, this.movesCount);
                commandResult.AppendLine();
                commandResult.Append(GameFifteenConstants.AskNameMessage);
            }
            else
            {
                commandResult.Append(GameFifteenConstants.AskNumberMessage);
            }

            return commandResult.ToString();
        }

        /// <summary>
        /// Initializes the matrix and prepares it for the game by rearranging the field.
        /// </summary>
        private void Initialize()
        {
            this.emptyCellRow = this.field.Rows - 1;
            this.emptyCellColumn = this.field.Columns - 1;
            this.emptyCellValue = this.field.Rows * this.field.Columns;
            this.movesCount = 0;

            this.InitializeField();
            this.RearrangeField();
        }

        /// <summary>
        /// Draws/writes the starting screen description message.
        /// </summary>
        /// <returns>All the text of the starting screen</returns>
        private string ShowStartScreen()
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
        /// Draws/writes the matrix itself.
        /// </summary>
        /// <returns>The matrix as a string</returns>
        private string ShowField()
        {
            var output = new StringBuilder();
            output.AppendLine(" -------------");
            for (int i = 0; i < this.field.Rows; i++)
            {
                output.Append("|");
                for (int j = 0; j < this.field.Columns; j++)
                {
                    if (this.field[i, j] <= 9)
                    {
                        output.AppendFormat("  {0}", this.field[i, j]);
                    }
                    else if (this.field[i, j] == this.emptyCellValue)
                    {
                        output.Append("   ");
                    }
                    else
                    {
                        output.AppendFormat(" {0}", this.field[i, j]);
                    }

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
        /// Display the result on the console
        /// </summary>
        /// <param name="output">The output which will be display on the console</param>
        private void RenderCommandResult(string output)
        {
            this.renderer.Output(output);
        }

        /// <summary>
        /// Ends the game by saving the player's score and creating a new Player instance
        /// </summary>
        /// <param name="command">Input command</param>
        /// <returns>The desired command</returns>
        private ICommand EndGame(ICommand command)
        {
            string playerName = command.Name;
            this.SavePlayerScore(new Player(playerName, this.movesCount));

            command = Command.Parse("restart");
            return command;
        }

        /// <summary>
        /// Randomly rearranges the field to prepare it for the game start.
        /// </summary>
        private void RearrangeField()
        {
            int shuffles = this.randomNumberGenerator.Next(
                GameFifteenConstants.FieldMinimumShuffles, GameFifteenConstants.FieldMaximumShuffles);
            for (int i = 0; i < shuffles; i++)
            {
                int randomDirectionIndex = this.randomNumberGenerator.Next(DirRow.Length - 1);
                int newRowIndex = this.emptyCellRow + DirRow[randomDirectionIndex];
                int newColIndex = this.emptyCellColumn + DirColumn[randomDirectionIndex];

                if (!this.IsInside(newRowIndex, newColIndex))
                {
                    // step back
                    i--;
                    continue;
                }

                this.MoveEmptyCell(newRowIndex, newColIndex);
            }

            if (this.CheckIfFieldIsSolved())
            {
                this.RearrangeField();
            }
        }

        /// <summary>
        /// Checks whether the number input by the user is inside the matrix by its coordinates.
        /// </summary>
        /// <param name="row">Current cell row</param>
        /// <param name="col">Current cell column</param>
        /// <returns>True or false</returns>
        private bool IsInside(int row, int col)
        {
            return 0 <= row && row < this.field.Rows &&
                   0 <= col && col < this.field.Columns;
        }

        /// <summary>
        /// Moves the empty cell according to the number command provided by the user.
        /// </summary>
        /// <param name="newRow">Cell row</param>
        /// <param name="newCol">Cell column</param>
        private void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = this.field[newRow, newCol];
            this.field[newRow, newCol] = this.emptyCellValue;
            this.field[this.emptyCellRow, this.emptyCellColumn] = swapValue;

            this.emptyCellRow = newRow;
            this.emptyCellColumn = newCol;
        }

        /// <summary>
        /// Moves the number provided by the command to the empty cell.
        /// </summary>
        /// <param name="destinationValue">Destination cell</param>
        /// <returns>The redrawn matrix as a string</returns>
        private string Move(string destinationValue)
        {
            var result = new StringBuilder();
            bool isDestinationValid = false;
            int number;

            if (int.TryParse(destinationValue, out number) &&
                number >= 1 &&
                number < this.emptyCellValue)
            {
                int nextRow = 0;
                int nextCol = 0;

                for (int i = 0; i < DirRow.Length; i++)
                {
                    nextRow = this.emptyCellRow + DirRow[i];
                    nextCol = this.emptyCellColumn + DirColumn[i];

                    if (this.IsInside(nextRow, nextCol) &&
                        this.field[nextRow, nextCol] == number)
                    {
                        this.MoveEmptyCell(nextRow, nextCol);
                        this.movesCount++;
                        isDestinationValid = true;
                        break;
                    }
                }
            }

            if (isDestinationValid)
            {
                result.AppendLine(this.ShowField());
            }
            else
            {
                result.AppendLine(GameFifteenConstants.InvalidCommandMessage);
            }

            return result.ToString();
        }

        /// <summary>
        /// Creates the scoreboard and shows it upon game end.
        /// </summary>
        /// <returns>The scoreboard as a string</returns>
        private string ShowScoreboard()
        {
            var output = new StringBuilder();
            output.AppendLine(GameFifteenConstants.ScoreboardTitle);

            var players = this.scoreboard.Players;
            for (int i = 0; i < players.Count; i++)
            {
                output.AppendFormat(GameFifteenConstants.ScoreboardView, i + 1, players[i].Name, players[i].Moves);
                output.AppendLine();
            }

            return output.ToString();
        }

        /// <summary>
        /// Saves the player's score at the end of a game.
        /// </summary>
        /// <param name="player">The current player we want to add</param>
        private void SavePlayerScore(IPlayer player)
        {
            this.scoreboard.AddPlayer(player);
        }

        /// <summary>
        /// Checks whether the game has come to a solution and proceeds to asking for the player's name.
        /// </summary>
        /// <returns>A boolean result whether to proceed to end or not</returns>
        private bool CheckIfFieldIsSolved()
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
        /// Field initializer
        /// </summary>
        private void InitializeField()
        {
            int fillValue = 1;
            for (int i = 0; i < this.field.Length; i++)
            {
                this.field[i] = fillValue;
                fillValue++;
            }
        }
    }
}