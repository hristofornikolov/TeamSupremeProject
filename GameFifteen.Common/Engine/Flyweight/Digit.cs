//-----------------------------------------------------------------------
// <copyright file="Digit.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// An parent class for the 10 digits
    /// </summary>
    internal class Digit
    {
        /// <summary>
        /// The digit characters are held in this private field
        /// </summary>
        protected char symbol;

        /// <summary>
        /// Overrides the ToString method to return the digit's character.
        /// </summary>
        /// <returns>The digit's character</returns>
        public override string ToString()
        {
            return this.symbol.ToString();
        }
    }
}
