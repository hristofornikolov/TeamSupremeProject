namespace GameFifteenProject.Engine
{
    using System.Text;
    using GameFifteenProject.Contracts;
    using GameFifteenProject.Contracts.Engine;
    using GameFifteenProject.Extensions;
    using GameFifteenProject.GameObjects;
    
    public sealed class GameFifteenEngine
    {
        private static GameFifteenEngine instance;

        // All possible directions for moving the cells
        private static readonly int[] dirRow = { -1, 0, 1, 0 };
        private static readonly int[] dirColumn = { 0, 1, 0, -1 };

        private readonly FieldMatrix field;
        private readonly IRenderer renderer;
        private readonly IScoreboard scoreboard;
        private readonly IRandomNumberGenerator randomNumberGenerator;

        private int emptyCellRow;
        private int emptyCellColumn;
        private int emptyCellValue;
        private int movesCount;

        private GameFifteenEngine()
        {
            this.field = new FieldMatrix();
            this.renderer = new ConsoleRenderer();
            this.scoreboard = new ScoreboardProxy();
            this.randomNumberGenerator = new RandomNumberGenerator();
        }

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
                    command = EndGame(command);
                }
            }
        }

        private ICommand ReadCommand()
        {
            var input = this.renderer.Input();
            var command = Command.Parse(input);

            return command;
        }

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

        private void Initialize()
        {
            this.emptyCellRow = this.field.Rows - 1;
            this.emptyCellColumn = this.field.Columns - 1;
            this.emptyCellValue = this.field.Rows * this.field.Columns;
            this.movesCount = 0;

            this.InitializeField();
            this.RearrangeField();
        }

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

        private void RenderCommandResult(string output)
        {
            this.renderer.Output(output);
        }

        private ICommand EndGame(ICommand command)
        {
            string playerName = command.Name;
            this.SavePlayerScore(new Player(playerName, this.movesCount));

            command = Command.Parse("restart");
            return command;
        }

        private void RearrangeField()
        {
            int shuffles = this.randomNumberGenerator.Next(
                GameFifteenConstants.FieldMinimumShuffles, GameFifteenConstants.FieldMaximumShuffles);
            for (int i = 0; i < shuffles; i++)
            {
                int randomDirectionIndex = this.randomNumberGenerator.Next(dirRow.Length - 1);
                int newRowIndex = this.emptyCellRow + dirRow[randomDirectionIndex];
                int newColIndex = this.emptyCellColumn + dirColumn[randomDirectionIndex];

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

        private bool IsInside(int row, int col)
        {
            return 0 <= row && row < this.field.Rows &&
                   0 <= col && col < this.field.Columns;
        }

        private void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = this.field[newRow, newCol];
            this.field[newRow, newCol] = this.emptyCellValue;
            this.field[this.emptyCellRow, this.emptyCellColumn] = swapValue;

            this.emptyCellRow = newRow;
            this.emptyCellColumn = newCol;
        }

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
                for (int i = 0; i < dirRow.Length; i++)
                {
                    nextRow = this.emptyCellRow + dirRow[i];
                    nextCol = this.emptyCellColumn + dirColumn[i];

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

        private string ShowScoreboard()
        {
            var output = new StringBuilder();
            output.AppendLine(GameFifteenConstants.ScoreboardTitle);

            var players = this.scoreboard.Players;
            for (int i = 0; i < players.Count; i++)
            {
                output.AppendFormat(GameFifteenConstants.ScoreboardView,
                    i + 1, players[i].Name, players[i].Moves);
                output.AppendLine();
            }

            return output.ToString();
        }

        private void SavePlayerScore(IPlayer player)
        {
            this.scoreboard.AddPlayer(player);
        }

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