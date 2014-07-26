//-----------------------------------------------------------------------
// <copyright file="Digit8.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Flyweight
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class for the eight digit.
    /// </summary>
    internal class Digit8 : Digit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Digit8"/> class.
        /// </summary>
        public Digit8()
        {
            this.symbol = '8';
        }
    }
}
