namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Contracts;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.Engine;
    using GameFifteen.Engine.Factories;
    using GameFifteen.GameObjects;
    using GameFifteen.Extensions;

    /// <summary>
    /// Unit test methods for class ExitCommand
    /// </summary>
    [TestClass]
    public class UnitTestExitCommand
    {
        [TestMethod]
        public void CheckIfExitCommandConstructorWorksProperly()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            ExitCommand exitCommand = new ExitCommand(gameEngine);

            Assert.IsInstanceOfType(exitCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodExecuteReturnsProperString()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            ExitCommand exitCommand = new ExitCommand(gameEngine);

            string result = exitCommand.Execute();

            Assert.AreEqual(result, "exit");
        }
    }
}
