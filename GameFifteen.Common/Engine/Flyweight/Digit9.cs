//-----------------------------------------------------------------------
// <copyright file="Digit9.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class for the ninth digit.
    /// </summary>
    internal class Digit9 : Digit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit9"/> class.
        /// </summary>
        public Digit9()
        {
            this.symbol = '9';
        }
    }
}
