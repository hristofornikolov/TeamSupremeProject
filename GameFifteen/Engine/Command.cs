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
        /// <summary>
        /// Field with commands name
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class
        /// </summary>
        /// <param name="name">The name of the command</param>
        private Command(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets the name of a command
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Command parser
        /// </summary>
        /// <param name="input">Console input</param>
        /// <returns>A ready command</returns>
        public static Command Parse(string input)
        {
            return new Command(input);
        }
    }
}