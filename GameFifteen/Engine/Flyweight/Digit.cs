namespace GameFifteen.Engine.Flyweight
{
    using System;
    using System.Linq;

    internal class Digit
    {
        protected char symbol;

        public override string ToString()
        {
            return this.symbol.ToString();
        }
    }
}
