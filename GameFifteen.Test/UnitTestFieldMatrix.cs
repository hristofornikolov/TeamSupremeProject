namespace GameFifteen.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteenProject.GameObjects;

    [TestClass]
    public class UnitTestFieldMatrix
    {
        [TestMethod]
        public void TestNewFieldMatrixConstructorCorrectSize()
        {
            FieldMatrix fieldMatrix = new FieldMatrix();
            Assert.AreEqual(fieldMatrix.Rows, 4);
            Assert.AreEqual(fieldMatrix.Columns, 4);
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


    }
}
