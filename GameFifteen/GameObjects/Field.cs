//-----------------------------------------------------------------------
// <copyright file="MatrixGenerator.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.GameObjects
{
    using GameFifteenProject.Engine;

    using System.Collections.Generic;

    public class Field : IEnumerable<int>
    {
        private const int InitialRows = 4;
        private const int InitialColumns = 4;

        private int[,] matrix;

        public Field()
        {
            this.matrix = new int[InitialRows, InitialColumns];
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
            get { return InitialRows; }
        }

        public int Columns
        {
            get { return InitialColumns; }
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
                for (int i = 0; i < InitialRows; i++)
                {
                    for (int j = 0; j < InitialColumns; j++)
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
                for (int i = 0; i < InitialRows; i++)
                {
                    for (int j = 0; j < InitialColumns; j++)
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

        public bool isSolved()
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
