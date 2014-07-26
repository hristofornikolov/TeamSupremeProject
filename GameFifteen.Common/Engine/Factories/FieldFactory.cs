//-----------------------------------------------------------------------
// <copyright file="FieldFactory.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Factories
{
    using System;
    using System.Linq;
    using GameFifteen.Common.Contracts;

    /// <summary>
    /// Class for creating a playing field with a given size
    /// </summary>
    public sealed class FieldFactory
    {
        /// <summary>
        /// A class field holding a specific instance of the class
        /// </summary>
        private static FieldFactory instance; 

        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="FieldFactory" /> class from being created.
        /// </summary>
        private FieldFactory()
        {
        }

        /// <summary>
        /// Gets an instance of the FieldFactory class. 
        /// Creates a new instance if such does not exist already
        /// </summary>
        public static FieldFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FieldFactory();
                }

                return instance;
            }
        }

        /// <summary>
        /// Method for creating a field with three different size options
        /// </summary>
        /// <param name="size">The number of rows/columns in the field</param>
        /// <returns>A new MatrixField object</returns>
        public IMatrixField GetField(int size)
        {
            switch (size)
            {
                case 4:
                    return new MatrixField(4, 4);
                case 5:
                    return new MatrixField(5, 5);
                case 6:
                    return new MatrixField(6, 6);
                default:
                    return new MatrixField(4, 4);
            }
        }
    }
}