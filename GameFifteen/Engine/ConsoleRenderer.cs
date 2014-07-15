namespace GameFifteen.Engine
{
    using System;
    using GameFifteenProject.Contracts.Engine;

    public class ConsoleRenderer : IRenderer
    {
        /// <summary>
        /// Console reading method
        /// </summary>
        /// <returns>The input read</returns>
        public string Input()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Console writing method
        /// </summary>
        /// <param name="output">The output written</param>
        public void Output(string output)
        {
            Console.Write(output);
        }
    }
}