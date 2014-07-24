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
    using System.Diagnostics.CodeAnalysis;
    
    /// <summary>
    /// This is the start point of the game.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GameFifteenProgram
    {
        /// <summary>
        /// Method to starts the game
        /// </summary>
        public static void Main()
        {
            IMatrixField field = FieldFactory.Instance.GetField(4);
            IScoreboard scoreboard = new ScoreboardProxy();
            IRandomNumberGenerator random = new RandomNumberGenerator();
            IGameEngine gameEngine = new GameFifteenEngine(field, scoreboard, random);

            IRenderer renderer = new ConsoleRenderer();
            IInputHandler inputHandler = new InputHandler();
            IGameController gameFifteenControl = new GameController(gameEngine, inputHandler, renderer);

            gameFifteenControl.Start();
        }
    }
}