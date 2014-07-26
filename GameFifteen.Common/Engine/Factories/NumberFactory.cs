//-----------------------------------------------------------------------
// <copyright file="NumberFactory.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//--------------------------------------------------------------------

namespace GameFifteen.Common.Engine.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameFifteen.Common.Engine.Flyweight;

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    internal sealed class NumberFactory
    {
        /// <summary>
        /// Dictionary type of field to keep pairs of the chars and Digit objects
        /// </summary>
        private readonly Dictionary<char, Digit> digits = new Dictionary<char, Digit>();

        /// <summary>
        /// Instance of the NumberFactory class
        /// </summary>
        private static NumberFactory instance;

        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="NumberFactory" /> class from being created.
        /// </summary>
        private NumberFactory()
        {
        }

        /// <summary>
        /// Gets the singleton instance
        /// </summary>
        public static NumberFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NumberFactory();
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets digit's reference
        /// </summary>
        /// <param name="key">The character of the digit</param>
        /// <returns>Given digit's reference</returns>
        public Digit GetDigit(char key)
        {
            Digit digit = null;
            if (this.digits.ContainsKey(key))
            {
                digit = this.digits[key];
            }
            else
            {
                switch (key)
                {
                    case '0':
                        digit = new Digit0();
                        break;
                    case '1':
                        digit = new Digit1();
                        break;
                    case '2':
                        digit = new Digit2();
                        break;
                    case '3':
                        digit = new Digit3();
                        break;
                    case '4':
                        digit = new Digit4();
                        break;
                    case '5':
                        digit = new Digit5();
                        break;
                    case '6':
                        digit = new Digit6();
                        break;
                    case '7':
                        digit = new Digit7();
                        break;
                    case '8':
                        digit = new Digit8();
                        break;
                    case '9':
                        digit = new Digit9();
                        break;
                }

                this.digits.Add(key, digit);
            }

            return digit;
        }
    }
}