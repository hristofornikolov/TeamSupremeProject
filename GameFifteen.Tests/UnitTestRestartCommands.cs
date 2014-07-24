namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common.Engine.Factories;
    using GameFifteen.Common.Engine;
    using GameFifteen.Common;

    /// <summary>
    /// Unit test methods for class RestartCommands
    /// </summary>
    [TestClass]
    public class UnitTestRestartCommands
    {
        [TestMethod]
        public void CheckIfRestartCommandConstructorWorksProperly()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, scoreboard, random);

            RestartCommand restartCommand = new RestartCommand(gameEngine);

            Assert.IsInstanceOfType(restartCommand, typeof(Command));
        }

        [TestMethod]
        public void CheckIfMethodRestartExecuteReturnsProperString()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, scoreboard, random);

            RestartCommand restartCommand = new RestartCommand(gameEngine);

            string result = restartCommand.Execute();

            Assert.IsInstanceOfType(result, typeof(String));
        }
    }
}
