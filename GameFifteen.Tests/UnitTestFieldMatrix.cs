//-----------------------------------------------------------------------
// <copyright file="UnitTestFieldMatrix.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Common;

    [TestClass]
    public class UnitTestFieldMatrix
    {
        [TestMethod]
        public void CheckNewFieldMatrixConstructorCorrectSize()
        {
            MatrixField fieldMatrix = new MatrixField(4, 4);
            Assert.AreEqual(4, fieldMatrix.Rows);
            Assert.AreEqual(4, fieldMatrix.Columns);
        }

        [TestMethod]
        public void CheckNewFieldMatrixConstructorCorrectInitialization()
        {
            MatrixField fieldMatrix = new MatrixField(4, 4);
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
            MatrixField fieldMatrix = new MatrixField(4, 4);
            int testlength = 16;
            Assert.AreEqual(testlength, fieldMatrix.Length);
        }

        [TestMethod]
        public void CheckLinearIndex()
        {
            MatrixField fieldMatrix = new MatrixField(4, 4);
            int counter = 0;
            for (int i = 0; i < fieldMatrix.Rows; i++)
            {
                for (int j = 0; j < fieldMatrix.Columns; j++)
                {
                    if (counter != j + (fieldMatrix.Rows * i))
                    {
                        throw new ArgumentException("Incorrect linear index!");
                    }

                    counter++;
                }
            }
        }

        [TestMethod]
        public void CheckGetterandSetter()
        {
            MatrixField fieldMatrix = new MatrixField(4, 4);
            fieldMatrix[1, 1] = 7;
            Assert.AreEqual(7, fieldMatrix[1, 1]);
        }

        [TestMethod]
        public void CheckGetterandSetterViaTheNewIndex()
        {
            MatrixField fieldMatrix = new MatrixField(4, 4);
            fieldMatrix[8] = 12;
            Assert.AreEqual(12, fieldMatrix[8]);
        }
    }
}