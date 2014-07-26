//-----------------------------------------------------------------------
// <copyright file="Digit5.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class for the fifth digit.
    /// </summary>
    internal class Digit5 : Digit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit5"/> class.
        /// </summary>
        public Digit5()
        {
            this.symbol = '5';
        }
    }
}
