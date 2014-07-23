namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

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