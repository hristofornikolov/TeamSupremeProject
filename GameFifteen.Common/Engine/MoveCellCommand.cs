namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

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