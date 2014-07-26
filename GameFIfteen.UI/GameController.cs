//-----------------------------------------------------------------------
// <copyright file="GameController.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.UI
{
    using System;
    using System.Linq;
    using System.Text;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common.Engine;
    
    /// <summary>
    /// Controller class for the game
    /// </summary>
    internal class GameController : IGameController
    {
        private readonly IGameEngine gameEngine;
        private readonly IInputHandler inputReader;
        private readonly IRenderer renderer;

        private Command currentCmd;

        public GameController(IGameEngine gameEngine, IInputHandler inputReader, IRenderer renderer)
        {
            this.gameEngine = gameEngine;
            this.inputReader = inputReader;
            this.renderer = renderer;
            this.currentCmd = null;
        }

        /// <summary>
        /// Displays the win message and logs the player score
        /// </summary>
        private void FinishGame()
        {
            var output = new StringBuilder();
            output.AppendLine(this.gameEngine.GetField());
            output.AppendLine(String.Format(GlobalConstants.WinMessage, this.gameEngine.PlayerMoves));
            output.Append(GlobalConstants.AskNameMessage);
            this.renderer.Output(output.ToString());

            string playerName = this.inputReader.GetInput();
            this.gameEngine.SavePlayerScore(playerName, this.gameEngine.PlayerMoves);
        }

        /// <summary>
        /// Starts a new game
        /// </summary>
        public void Start()
        {
            this.renderer.Output(this.gameEngine.Restart());

            while (!(this.currentCmd is ExitCommand) &&
                   !this.gameEngine.IsFieldArrange())
            {
                string input = this.inputReader.GetInput();
                string cmdResult = this.ExecuteCommand(input);
                this.renderer.Output(cmdResult);
            }

            if (this.gameEngine.IsFieldArrange())
            {
                this.FinishGame();

                this.Start();
            }

            this.renderer.Output(Environment.NewLine);
        }
        
        /// <summary>
        /// Executes a given command
        /// </summary>
        /// <param name="userInput">Input command from the user</param>
        /// <returns>Executes the corresponding command</returns>
        public virtual string ExecuteCommand(string userInput)
        {
            switch (userInput)
            {
                case "restart":
                    this.currentCmd = new RestartCommand(this.gameEngine);
                    break;
                case "exit":
                    this.currentCmd = new ExitCommand(this.gameEngine);
                    break;
                case "top":
                    this.currentCmd = new TopCommand(this.gameEngine);
                    break;
                default:
                    this.currentCmd = new MoveCellCommand(this.gameEngine, userInput);
                    break;
            }

            return this.currentCmd.Execute();
        }
    }
}