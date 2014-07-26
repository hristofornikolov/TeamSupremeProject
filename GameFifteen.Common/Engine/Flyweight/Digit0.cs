//-----------------------------------------------------------------------
// <copyright file="Digit0.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//--------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class for the zero digit.
    /// </summary>
    internal class Digit0 : Digit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit0"/> class.
        /// </summary>
        public Digit0()
        {
            this.symbol = '0';
        }
    }
}
