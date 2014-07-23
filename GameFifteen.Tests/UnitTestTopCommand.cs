namespace GameFifteen.Tests
{
    using System;
    using GameFifteen.UI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common.Engine;
    using GameFifteen.Common.Engine.Factories;
    using GameFifteen.Common;

    /// <summary>
    /// Unit test methods for class TopCommand
    /// </summary>
    [TestClass]
    public class UnitTestTopCommand
    {
        [TestMethod]
        public void CheckIfTopCommandConstructorWorksProperly()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            TopCommand topCommand = new TopCommand(gameEngine);

            Assert.IsInstanceOfType(topCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodTopExecuteReturnsProperEmptyString()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            TopCommand topCommand = new TopCommand(gameEngine);

            string result = topCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }

        [TestMethod]
        public void CheckIfMethodTopExecuteReturnsProperString()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            TopCommand topCommand = new TopCommand(gameEngine);
            Player player = new Player("Pesho", 4);
            scoreboard.AddPlayer(player);

            string result = topCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
