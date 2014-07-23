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
    /// Unit test methods for class MoveCellCommand
    /// </summary>
    [TestClass]
    public class UnitTestMoveCellCommand
    {
        [TestMethod]
        public void CheckIfmoveCellCommandCommandConstructorWorksProperly()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            string destination = "restart";

            MoveCellCommand moveCellCommand = new MoveCellCommand(gameEngine, destination);

            Assert.IsInstanceOfType(moveCellCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodMoveCellCommandExecuteReturnsProperString()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            string destination = "restart";

            MoveCellCommand moveCellCommand = new MoveCellCommand(gameEngine, destination);

            string result = moveCellCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }

        [TestMethod]
        public void CheckIfMethodMoveCellCommandExecuteReturnsProperStringTwo()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            string destination = "9";

            MoveCellCommand moveCellCommand = new MoveCellCommand(gameEngine, destination);

            string result = moveCellCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}