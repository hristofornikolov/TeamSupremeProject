﻿//-----------------------------------------------------------------------
// <copyright file="Command.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteenProject.Engine
{
    using GameFifteenProject.Contracts.Engine;

    /// <summary>
    /// Class that parse commands
    /// </summary>
    public class Command : ICommand
    {
        private string name;

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
