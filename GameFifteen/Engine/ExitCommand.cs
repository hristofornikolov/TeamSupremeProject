namespace GameFifteen.Engine
{
    using System;
    using System.Linq;

    public class ExitCommand : Command
    {
        public ExitCommand(GameFifteenEngine gameEngine) : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Exit();
        }
    }
}