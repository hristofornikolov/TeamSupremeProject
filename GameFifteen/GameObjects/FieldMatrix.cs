//-----------------------------------------------------------------------
// <copyright file="MatrixGenerator.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.GameObjects
{
    using GameFifteenProject.Engine;

    using System.Collections.Generic;

    public class FieldMatrix : IEnumerable<int>
    {
        private int[,] matrix;

        public FieldMatrix()
        {
            this.matrix = new int[GameFifteenConstants.FieldInitialRows, GameFifteenConstants.FieldInitialColumns];
        }

        public void Initialize()
        {

            int fillValue = 1;
            for (int i = 0; i < this.Length; i++)
            {
                this[i] = fillValue;
                fillValue++;
            }
        }

        public int Rows
        {
            get { return GameFifteenConstants.FieldInitialRows; }
        }

        public int Columns
        {
            get { return GameFifteenConstants.FieldInitialColumns; }
        }

        public int Length
        {
            get { return this.matrix.Length; }
        }

        public int this[int index]
        {
            get
            {
                int value = 0;
                bool isMatch = false;

                int currentIndex = 0;
                for (int i = 0; i < GameFifteenConstants.FieldInitialRows; i++)
                {
                    for (int j = 0; j < GameFifteenConstants.FieldInitialColumns; j++)
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
                for (int i = 0; i < GameFifteenConstants.FieldInitialRows; i++)
                {
                    for (int j = 0; j < GameFifteenConstants.FieldInitialColumns; j++)
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

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Length; i++)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool CheckIfSolved()
        {
            int value = 1;
            for (int i = 0; i < this.Length; i++)
            {
                if (this[i] != value)
                {
                    return false;
                }

                value++;
            }

            return true;
        }
    }
}
