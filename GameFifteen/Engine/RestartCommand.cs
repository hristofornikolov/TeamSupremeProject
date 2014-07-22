namespace GameFifteen.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Contracts.Engine;

    public class RestartCommand : Command
    {
        public RestartCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Restart();
        }
    }
}