namespace GameFifteen.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.GameObjects;

    /// <summary>
    /// Summary description for ScoreboardProxy
    /// </summary>
    [TestClass]
    public class UnitTestScoreboardProxy
    {
        [TestMethod]
        public void CheckIfPlayersListIsCorrect()
        {
            Player ivan = new Player("Ivan", 43);
            Player stoyan = new Player("Stoyan", 35);
            Player yasen = new Player("Yasen", 57);

            ScoreboardProxy scoreboard = new ScoreboardProxy();
            scoreboard.AddPlayer(ivan);
            scoreboard.AddPlayer(stoyan);
            scoreboard.AddPlayer(yasen);

            Assert.IsTrue(scoreboard.Players[0].Name == "Stoyan" && scoreboard.Players[0].Moves == 35 &&
                scoreboard.Players[1].Name == "Ivan" && scoreboard.Players[1].Moves == 43 &&
                scoreboard.Players[2].Name == "Yasen" && scoreboard.Players[2].Moves == 57);
        }

        
    }
}
