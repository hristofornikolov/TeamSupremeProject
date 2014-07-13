namespace GameFifteenProject.Engine
{
    using GameFifteenProject.Contracts.Engine;

    using System;

    public class ConsoleRenderer : IRenderer
    {
        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string output)
        {
            Console.Write(output);
        }
    }
}
