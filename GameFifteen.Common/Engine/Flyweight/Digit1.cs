//-----------------------------------------------------------------------
// <copyright file="Digit1.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class for the first digit.
    /// </summary>
    internal class Digit1 : Digit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit1"/> class.
        /// </summary>
        public Digit1()
        {
            this.symbol = '1';
        }
    }
}
