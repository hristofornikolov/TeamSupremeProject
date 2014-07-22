namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Extensions;

    /// <summary>
    /// Summary description for UnitTestRandomGenerator
    /// </summary>
    [TestClass]
    public class UnitTestRandomGenerator
    {
        [TestMethod]
        public void CheckIfConsecutiveRandomNumbersAreDifferent()
        {
            RandomNumberGenerator randomNumber = new RandomNumberGenerator();
            int nextRandomNumber = randomNumber.Next();

            Assert.AreNotEqual(randomNumber, nextRandomNumber);
        }

        [TestMethod]
        public void CheckIfGeneratedRandomNumberIsLessThanUpperLimit()
        {
            RandomNumberGenerator randomNumber = new RandomNumberGenerator();
            int testMaxValue = 257;
            int nextRandomNumber = randomNumber.Next(testMaxValue);

            Assert.IsTrue(nextRandomNumber < testMaxValue);
        }

        [TestMethod]
        public void CheckIfGeneratedRandomNumberIsInInterval()
        {
            RandomNumberGenerator randomNumber = new RandomNumberGenerator();
            int testMinValue = 2014;
            int testMaxValue = 666666;
            int nextRandomNumber = randomNumber.Next(testMinValue, testMaxValue);

            Assert.IsTrue(nextRandomNumber < testMaxValue && nextRandomNumber > testMinValue);
        }
    }
}
