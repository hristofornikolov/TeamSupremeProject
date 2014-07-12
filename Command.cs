//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Class that manages the commands
    /// </summary>
    public static class Command
    {
        /// <summary>
        /// All possibilities for the commands
        /// </summary>
        private enum Commands 
        { 
            /// <summary>
            /// Command for restarting the game
            /// </summary>
            restart,

            /// <summary>
            /// Command for showing the top players
            /// </summary>
            top,

            /// <summary>
            /// Command for exiting the game
            /// </summary>
            exit 
        }

        /// <summary>
        /// Method that takes the command from the user
        /// </summary>
        /// <param name="input">Command written by the user</param>
        /// <returns>The command if it is valid, 
        /// exception elsewhere</returns>
        public static string CommandType(string input)
        {
            string inputToLower = input.ToLower();
            string output;

            if (inputToLower == Commands.exit.ToString() || inputToLower == Commands.restart.ToString() || inputToLower == Commands.top.ToString())
            {
                output = inputToLower;
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }

            return output;
        }
    }
}
