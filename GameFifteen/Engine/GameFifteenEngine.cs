namespace GameFifteenProject.Engine
{
    using GameFifteenProject.Contracts.Engine;
    using GameFifteenProject.Extensions;
    using GameFifteenProject.GameObjects;

    using System.Text;

    public sealed class GameFifteenEngine
    {
        private const string AskNameMessage = "Please enter your name for the scoreboard: ";
        private const string AskNumberMessage = "Enter a number to move: ";
        private const string InvalidCommandMessage = "Invalid move or command.";
        private const string WinMessage = "Well done! You won the game in {0} moves.";

        // 1, 1 is for testing
        private const int MinimumShuffles = 1;  
        private const int MaximumShuffles = 1; 

        private static GameFifteenEngine instance;

        // All possible directions for moving the cells
        private static readonly int[] dirRow = { -1, 0, 1, 0 };
        private static readonly int[] dirColumn = { 0, 1, 0, -1 };

        private readonly FieldMatrix field;
        private readonly IRenderer renderer;
        private readonly Scoreboard scoreboard;

        private int emptyCellRow;
        private int emptyCellColumn;
        private int emptyCellValue;
        private int movesCount;

        private GameFifteenEngine()
        {
            this.field = new FieldMatrix();
            this.renderer = new ConsoleRenderer();
            this.scoreboard = new Scoreboard();
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
            ICommand command = Command.Parse("start");
            while (command.Name != "exit")
            {
                string commandResult = this.ProcessCommand(command);
                this.RenderCommandResult(commandResult);
                command = this.ReadCommand();

                if (this.field.CheckIfSolved())
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
                case "start":
                    this.Initialize();
                    commandResult.AppendLine();
                    commandResult.AppendLine(this.ShowStartScreen());
                    commandResult.AppendLine(this.ShowField());
                    break;
                case "exit":
                    commandResult.AppendLine(command.Name);
                    break;
                case "scoreboard":
                    commandResult.AppendLine(this.ShowScoreboard());
                    break;
                default:
                    commandResult.AppendLine(this.Move(action));
                    break;
            }

            if (this.field.CheckIfSolved())
            {
                commandResult.AppendFormat(WinMessage, this.movesCount);
                commandResult.AppendLine();
                commandResult.Append(AskNameMessage);
            }
            else
            {
                commandResult.Append(AskNumberMessage);
            }

            return commandResult.ToString();
        }

        private void Initialize()
        {
            this.emptyCellRow = this.field.Rows - 1;
            this.emptyCellColumn = this.field.Columns - 1;
            this.emptyCellValue = this.field.Rows * this.field.Columns;
            this.movesCount = 0;

            this.field.Initialize();
            this.RearrangeField();
        }

        private string ShowStartScreen()
        {
            var output = new StringBuilder();
            output.AppendLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.");
            output.AppendLine("You can the following commands:");
            output.AppendLine("'start' -> to start a new game.");
            output.AppendLine("'scoreboard' -> to view the scoreboard.");
            output.AppendLine("'exit' -> to quit the game.");

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
            this.savePlayerScore(new Player(playerName, this.movesCount));

            command = Command.Parse("start");
            return command;
        }

        private void RearrangeField()
        {
            int shuffles = RandomNumberGenerator.Next(MinimumShuffles, MaximumShuffles);
            for (int i = 0; i < shuffles; i++)
            {
                int randomDirectionIndex = RandomNumberGenerator.Next(dirRow.Length - 1);
                int newRowIndex = this.emptyCellRow + dirRow[randomDirectionIndex];
                int newColIndex = this.emptyCellColumn + dirColumn[randomDirectionIndex];

                if (!isInside(newRowIndex, newColIndex))
                {
                    // step back
                    i--;
                    continue;
                }

                MoveEmptyCell(newRowIndex, newColIndex);
            }

            if (this.field.CheckIfSolved())
            {
                RearrangeField();
            }
        }

        private bool isInside(int row, int col)
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
                number < emptyCellValue)
            {
                int nextRow = 0;
                int nextCol = 0;
                for (int i = 0; i < dirRow.Length; i++)
                {
                    nextRow = this.emptyCellRow + dirRow[i];
                    nextCol = this.emptyCellColumn + dirColumn[i];

                    if (isInside(nextRow, nextCol) &&
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
                result.AppendLine(InvalidCommandMessage);
            }

            return result.ToString();
        }

        private string ShowScoreboard()
        {
            var output = new StringBuilder();
            output.AppendLine("Scoreboard:");

            var players = this.scoreboard.Players;
            for (int i = 0; i < players.Count; i++)
            {
                output.AppendFormat("{0}. {1} --> {2} moves", i + 1, players[i].Name, players[i].Moves);
                output.AppendLine();
            }

            return output.ToString();
        }

        private void savePlayerScore(Player player)
        {
            this.scoreboard.AddPlayer(player);
        }
    }
}
