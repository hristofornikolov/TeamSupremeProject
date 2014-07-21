namespace GameFifteen.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.GameObjects;

    [TestClass]
    public class UnitTestFieldMatrix
    {
        [TestMethod]
        public void TestNewFieldMatrixConstructorCorrectSize()
        {
            FieldMatrix fieldMatrix = new FieldMatrix();
            Assert.AreEqual(4, fieldMatrix.Rows);
            Assert.AreEqual(4, fieldMatrix.Columns);
        }

        [TestMethod]
        public void TestNewFieldMatrixConstructorCorrectInitialization()
        {
            FieldMatrix fieldMatrix = new FieldMatrix();
            for (int i = 0; i < fieldMatrix.Rows; i++)
            {
                for (int j = 0; j < fieldMatrix.Columns; j++)
                {
                    if (fieldMatrix[i, j] != 0)
                    {
                        throw new ArgumentException("When initialized, a cell value must be equal to zero!");
                    }
                }
            }

        }

        [TestMethod]
        public void TestNewFieldMatrixLengthPropertyValidity()
        {
            FieldMatrix fieldMatrix = new FieldMatrix();
            int testlength = 16;
            Assert.AreEqual(testlength, fieldMatrix.Length);
        }






    }
}
