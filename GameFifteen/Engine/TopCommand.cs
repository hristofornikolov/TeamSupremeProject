namespace GameFifteen.Engine
{
    using System;
    using System.Linq;

    public class TopCommand : Command
    {
        public TopCommand(GameFifteenEngine gameEngine) : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Top();
        }
    }
}