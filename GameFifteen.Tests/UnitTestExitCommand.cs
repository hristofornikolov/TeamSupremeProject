namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common.Engine;
    using GameFifteen.Common.Engine.Factories;
    using GameFifteen.Common;

    /// <summary>
    /// Unit test methods for class ExitCommand
    /// </summary>
    [TestClass]
    public class UnitTestExitCommand
    {
        [TestMethod]
        public void CheckIfExitCommandConstructorWorksProperly()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, scoreboard, random);

            ExitCommand exitCommand = new ExitCommand(gameEngine);

            Assert.IsInstanceOfType(exitCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodExitExecuteReturnsProperString()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, scoreboard, random);

            ExitCommand exitCommand = new ExitCommand(gameEngine);

            string result = exitCommand.Execute();

            Assert.AreEqual(result, GlobalConstants.ExitMessage);
        }
    }
}