//-----------------------------------------------------------------------
// <copyright file="UnitTestFieldFactory.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common.Engine.Factories;
    using GameFifteen.Common.Contracts;

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
            IMatrixField field = FieldFactory.Instance.GetField(4);

            Assert.IsInstanceOfType(field, typeof(IMatrixField));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithFiveRowsAndColumns()
        {
            IMatrixField field = FieldFactory.Instance.GetField(5);

            Assert.IsInstanceOfType(field, typeof(IMatrixField));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithSixRowsAndColumns()
        {
            IMatrixField field = FieldFactory.Instance.GetField(6);

            Assert.IsInstanceOfType(field, typeof(IMatrixField));
        }

        [TestMethod]
        public void CheckIfGetFieldReturnsProperMatrixWithDefaultRowsAndColumns()
        {
            IMatrixField field = FieldFactory.Instance.GetField(9);

            Assert.IsInstanceOfType(field, typeof(IMatrixField));
        }
    }
}
