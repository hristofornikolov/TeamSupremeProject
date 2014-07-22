namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Contracts;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.Engine.Factories;
    using GameFifteen.Engine;
    using GameFifteen.GameObjects;
    using GameFifteen.Extensions;

    /// <summary>
    /// Summary description for UnitTestCommands
    /// </summary>
    [TestClass]
    public class UnitTestRestartCommands
    {
        [TestMethod]
        public void CheckIfCommandConstructorWorksProperly()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            RestartCommand command = new RestartCommand(gameEngine);

            Assert.IsInstanceOfType(command, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodExecuteReturnsProperString()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            RestartCommand command = new RestartCommand(gameEngine);

            string result = command.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
