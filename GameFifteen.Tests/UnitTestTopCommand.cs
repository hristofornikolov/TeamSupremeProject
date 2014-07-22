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
    /// Unit test methods for class TopCommand
    /// </summary>
    [TestClass]
    public class UnitTestTopCommand
    {
        [TestMethod]
        public void CheckIfCommandConstructorWorksProperly()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            TopCommand topCommand = new TopCommand(gameEngine);

            Assert.IsInstanceOfType(topCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodExecuteReturnsProperString()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            TopCommand topCommand = new TopCommand(gameEngine);

            string result = topCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
