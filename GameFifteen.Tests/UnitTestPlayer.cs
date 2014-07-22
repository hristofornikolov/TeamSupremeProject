namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.GameObjects;
    using GameFifteen.Engine;

    /// <summary>
    /// Summary description for UnitTestPlayer
    /// </summary>
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void CheckIfPlayerNameIsValidString()
        {
           Player player = new Player("Pesho", 5);

           Assert.AreSame("Pesho", player.Name);
        }

        [TestMethod]
        public void CheckIfPlayerNameIsNull()
        {
            string playerName = null;

            Player player = new Player(playerName, 5);

            Assert.AreSame("Unknown", player.Name);
        }

        [TestMethod]
        public void CheckIfPlayerNameIsEmpty()
        {
            string playerName = "";

            Player player = new Player(playerName, 5);

            Assert.AreSame("Unknown", player.Name);
        }

        [TestMethod]
        public void CheckIfPlayerMovesAreValid()
        {
            Player player = new Player("Pesho", 5);

            Assert.AreEqual(5, player.Moves);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckIfPlayerMovesValueIsNegative()
        {
            Player player = new Player("Pesho", -5);
        }
    }
}
