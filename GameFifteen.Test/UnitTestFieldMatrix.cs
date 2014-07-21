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




    }
}
