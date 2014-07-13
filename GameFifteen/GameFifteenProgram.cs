//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TeamSupreme">
//     Copyright TeamSupreme. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace GameFifteenProject
{
    using GameFifteenProject.Engine;

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
