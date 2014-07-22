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
    /// Unit test methods for class MoveCellCommand
    /// </summary>
    [TestClass]
    public class UnitTestMoveCellCommand
    {
        [TestMethod]
        public void CheckIfmoveCellCommandCommandConstructorWorksProperly()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            string destination = "restart";

            MoveCellCommand moveCellCommand = new MoveCellCommand(gameEngine, destination);

            Assert.IsInstanceOfType(moveCellCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodmoveCellCommandExecuteReturnsProperString()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            string destination = "restart";

            MoveCellCommand moveCellCommand = new MoveCellCommand(gameEngine, destination);

            string result = moveCellCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
