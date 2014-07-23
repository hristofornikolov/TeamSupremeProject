namespace GameFifteen.Common.Engine
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts.Engine;

    public class ExitCommand : Command
    {
        public ExitCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override string Execute()
        {
            return this.gameEngine.Exit();
        }
    }
}