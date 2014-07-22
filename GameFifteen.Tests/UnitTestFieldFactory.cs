namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Engine.Factories;
    using GameFifteen.Contracts;

    /// <summary>
    /// Unit test methods for class FieldFactory
    /// </summary>
    [TestClass]
    public class UnitTestFieldFactory
    {     
        [TestMethod]
        public void CheckIfThereIsOnlyOneInstance()
        {
            FieldFactory firstField = FieldFactory.Instance;

            FieldFactory secondField = FieldFactory.Instance;

            Assert.AreSame(firstField, secondField);
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithFourRowsAndColumns()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(4);

            Assert.IsInstanceOfType(field, typeof(IFieldMatrix));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithFiveRowsAndColumns()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(5);

            Assert.IsInstanceOfType(field, typeof(IFieldMatrix));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithSixRowsAndColumns()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(6);

            Assert.IsInstanceOfType(field, typeof(IFieldMatrix));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithDefaultRowsAndColumns()
        {
            IFieldMatrix field = FieldFactory.Instance.GetField(9);

            Assert.IsInstanceOfType(field, typeof(IFieldMatrix));
        }
    }
}
