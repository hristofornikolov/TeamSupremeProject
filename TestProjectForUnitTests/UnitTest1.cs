using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.GameObjects;

namespace TestProjectForUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player player = new Player("Pesho", 5);

            Assert.AreSame("Pesho", player.Name);
        }
    }
}
