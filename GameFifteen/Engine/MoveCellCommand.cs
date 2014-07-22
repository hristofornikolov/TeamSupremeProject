namespace GameFifteen.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Contracts.Engine;

    public class MoveCellCommand : Command
    {
        public MoveCellCommand(IGameEngine gameEngine, string destination) : base(gameEngine)
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