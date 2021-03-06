﻿//-----------------------------------------------------------------------
// <copyright file="MatrixField.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common
{ 
    using System.Collections;
    using System.Collections.Generic;
    using GameFifteen.Common.Contracts;

    /// <summary>
    /// Creation of the field matrix
    /// </summary>
    public class MatrixField : IMatrixField, IEnumerable<int>
    {
        /// <summary>
        /// Matrix bi-dimensional array initialization
        /// </summary>
        private readonly int[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixField"/> class
        /// </summary>
        public MatrixField(int rows, int columns)
        {
            this.matrix = new int[rows, columns];
        }
        
        /// <summary>
        /// Gets the rows property
        /// </summary>
        public int Rows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the columns property
        /// </summary>
        public int Columns
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        /// <summary>
        /// Gets the length property
        /// </summary>
        public int Length
        {
            get
            {
                return this.matrix.Length;
            }
        }

        /// <summary>
        /// Creation of a special index for traversing the bi-dimensional array as a mono-dimensional array
        /// </summary>
        /// <param name="index">The index of the respective cell</param>
        /// <returns>The respective cell value by the entered linear index</returns>
        public int this[int index]
        {
            get
            {
                int value = 0;
                bool isMatch = false;
                int currentIndex = 0;

                for (int i = 0; i < this.Rows; i++)
                {
                    for (int j = 0; j < this.Columns; j++)
                    {
                        if (currentIndex == index)
                        {
                            value = this.matrix[i, j];
                            isMatch = true;
                            break;
                        }

                        currentIndex++;
                    }

                    if (isMatch)
                    {
                        break;
                    }
                }

                return value;
            }

            set
            {
                int currentIndex = 0;
                for (int i = 0; i < this.Rows; i++)
                {
                    for (int j = 0; j < this.Columns; j++)
                    {
                        if (currentIndex == index)
                        {
                            this.matrix[i, j] = value;
                            return;
                        }

                        currentIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Creation of a special index for traversing the bi-dimensional array as a mono-dimensional array
        /// </summary>
        /// <param name="row">The index of the respective row</param>
        /// <param name="col">The index of the respective column</param>
        /// <returns>The respective cell value by the entered linear index</returns>
        public int this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        /// <summary>
        /// A method returning an enumerator that iterates through the array cells by the new index
        /// </summary>
        /// <returns>An IEnumerator object that can be used for iterating through the array cells</returns>
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Here we use the previously created IEnumerator method
        /// </summary>
        /// <returns>IEnumerator IEnumerable</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}