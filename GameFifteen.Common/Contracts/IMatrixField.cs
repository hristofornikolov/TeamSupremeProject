//-----------------------------------------------------------------------
// <copyright file="IMatrixField.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//--------------------------------------------------------------------

namespace GameFifteen.Common.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the MatrixField. Inherits IEnumerable
    /// </summary>
    public interface IMatrixField : IEnumerable<int>
    {
        /// <summary>
        /// Gets the number of rows in the matrix field
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the number of columns in the matrix field
        /// </summary>
        int Columns { get; }

        /// <summary>
        /// Gets the length property of the matrix field array
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Special index for traversing the bi-dimensional array as a mono-dimensional array
        /// </summary>
        /// <param name="index">The index of the respective cell</param>
        /// <returns>The respective cell value by the entered linear index</returns>
        int this[int index] { get; set; }

        /// <summary>
        /// Special index for traversing the bi-dimensional array as a mono-dimensional array
        /// </summary>
        /// <param name="row">The index of the respective row</param>
        /// <param name="col">The index of the respective column</param>
        /// <returns>The respective cell value by the entered linear index</returns>
        int this[int row, int col] { get; set; }
    }
}