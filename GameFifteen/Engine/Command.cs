//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen.Engine
{
    using GameFifteen.Contracts.Engine;
 
    /// <summary>
    /// Class that parse commands
    /// </summary>
    public class Command : ICommand
    {
        private readonly string name;

        private Command(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }
    }
}