namespace GameFifteen.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Contracts.Engine;

    public class TopCommand : Command
    {
        public TopCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Top();
        }
    }
}