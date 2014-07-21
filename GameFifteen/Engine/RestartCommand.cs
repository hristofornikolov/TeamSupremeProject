namespace GameFifteen.Engine
{
    using System;
    using System.Linq;

    public class RestartCommand : Command
    {
        public RestartCommand(GameFifteenEngine gameEngine) : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Restart();
        }
    }
}