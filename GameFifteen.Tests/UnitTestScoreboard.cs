namespace GameFifteen.Tests
{
    using System;
    using GameFifteen.GameObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit test for checking class Scoreboard.cs
    /// </summary>
    [TestClass]
    public class UnitTestScoreboard
    {
        [TestMethod]
        public void AddingNewPlayerShouldProperlyUpdateTheCount()
        {
            Scoreboard scoreboard = new Scoreboard();
            Player player = new Player("Pesho", 6);

            scoreboard.AddPlayer(player);

            Assert.AreEqual(1, scoreboard.Players.Count);
        }
    }
}
