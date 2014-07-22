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
    /// Unit test methods for class RestartCommands
    /// </summary>
    [TestClass]
    public class UnitTestRestartCommands
    {
        [TestMethod]
        public void CheckIfRestartCommandConstructorWorksProperly()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            RestartCommand restartCommand = new RestartCommand(gameEngine);

            Assert.IsInstanceOfType(restartCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodRestartExecuteReturnsProperString()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            RestartCommand restartCommand = new RestartCommand(gameEngine);

            string result = restartCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
