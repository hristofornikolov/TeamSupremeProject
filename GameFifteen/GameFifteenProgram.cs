//-----------------------------------------------------------------------
// <copyright file="GameFifteenProgram.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteen
{
    using GameFifteen.Engine;
 
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
            GameFifteenEngine.Instance.Start();
        }
    }
}