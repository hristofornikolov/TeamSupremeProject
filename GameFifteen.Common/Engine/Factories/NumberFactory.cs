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
        private readonly Dictionary<char, Digit> digits = new Dictionary<char, Digit>();

        private static NumberFactory instance;

        private NumberFactory()
        {
        }

        /// <summary>
        /// Returns the singleton instance
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
        /// <param name="key"></param>
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