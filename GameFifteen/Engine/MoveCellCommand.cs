namespace GameFifteen.Engine
{
    using System;
    using System.Linq;

    public class MoveCellCommand : Command
    {
        public MoveCellCommand(GameFifteenEngine gameEngine, string destination) : base(gameEngine)
        {
            this.Destination = destination;
        }

        public string Destination { get; set; }

        public override string Execute()
        {
            return this.gameEngine.MoveEmptyCell(this.Destination);
        }
    }
}