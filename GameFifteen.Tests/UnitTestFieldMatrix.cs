namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.GameObjects;

    [TestClass]
    public class UnitTestFieldMatrix
    {
        [TestMethod]
        public void CheckNewFieldMatrixConstructorCorrectSize()
        {
            FieldMatrix fieldMatrix = new FieldMatrix(4, 4);
            Assert.AreEqual(4, fieldMatrix.Rows);
            Assert.AreEqual(4, fieldMatrix.Columns);
        }

        [TestMethod]
        public void CheckNewFieldMatrixConstructorCorrectInitialization()
        {
            FieldMatrix fieldMatrix = new FieldMatrix(4 , 4);
            foreach (var cell in fieldMatrix)
            {
                if (cell != 0)
                    {
                        throw new ArgumentException("When initialized, a cell value must be equal to zero!");
                    }
            }
        }

        [TestMethod]
        public void CheckNewFieldMatrixLengthPropertyValidity()
        {
            FieldMatrix fieldMatrix = new FieldMatrix(4 , 4);
            int testlength = 16;
            Assert.AreEqual(testlength, fieldMatrix.Length);
        }          
    }
}
