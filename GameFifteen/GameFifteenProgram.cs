//-----------------------------------------------------------------------
// <copyright file="GameFifteenProgram.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen
{
    using GameFifteen.Contracts;
    using GameFifteen.Contracts.Engine;
    using GameFifteen.Engine;
    using GameFifteen.Extensions;
    using GameFifteen.GameObjects;
 
    /// <summary>
    /// This is the start point of the game.
    /// </summary>
    public class GameFifteenProgram
    {
        /// <summary>
        /// Method to starts the game
        /// </summary>
        public static void Main()
        {
            FieldMatrix field = new FieldMatrix();
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();

            var gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);
            Command currentCmd = null;
            
            string input = "restart";
            string result = string.Empty;
            do
            {
                switch (input)
                {
                    case "restart":
                        currentCmd = new RestartCommand(gameEngine);
                        result = currentCmd.Execute();
                        break;
                    case "exit":
                        currentCmd = new ExitCommand(gameEngine);
                        result = currentCmd.Execute();
                        break;
                    case "top":
                        currentCmd = new TopCommand(gameEngine);
                        result = currentCmd.Execute();
                        break;
                    default:
                        currentCmd = new MoveCellCommand(gameEngine, input);
                        result = currentCmd.Execute();
                        break;
                }

                renderer.Output(result);
                input = renderer.Input();
            }
            while (input != "exit");
        }
    }
}