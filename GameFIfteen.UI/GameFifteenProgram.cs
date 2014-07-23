//-----------------------------------------------------------------------
// <copyright file="GameFifteenProgram.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Contracts.Engine;
    using GameFifteen.Common.Engine;
    using GameFifteen.Common.Engine.Factories;
    
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
            IMatrixField field = FieldFactory.Instance.GetField(4);
            IRenderer renderer = new ConsoleRenderer();
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, renderer, scoreboard, random);

            Command currentCmd = null;          
            string input = "restart";
            do
            {
                string result = string.Empty;

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