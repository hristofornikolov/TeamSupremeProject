//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TeamSupreme">
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
        public static void Main()
        {
            GameFifteenEngine.Instance.Start();
        }
    }
}