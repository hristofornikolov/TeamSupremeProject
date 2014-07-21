namespace GameFifteen.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.GameObjects;

    /// <summary>
    /// Summary description for UnitTestPlayer
    /// </summary>
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void CheckIfPlayerNameIsValid()
        {
           Player player = new Player("Pesho", 5);

           Assert.AreSame("Pesho", player.Name);
        }
    }
}
