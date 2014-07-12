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
        /// Method that takes the command from the user
        /// </summary>
        /// <param name="input">Command written by the user</param>
        /// <returns>The command if it is valid, 
        /// exception elsewhere</returns>
        public static string ValidateCommand(string input)
        {
            string output;

            if (input == CommandType.Exit.ToString() ||
                input == CommandType.Restart.ToString() ||
                input == CommandType.Top.ToString())
            {
                output = input.ToLower();
            }
            else
            {
                throw new ArgumentException("Invalid Command!");
            }

            return output;
        }
    }
}
