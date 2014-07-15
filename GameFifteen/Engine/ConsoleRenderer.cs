namespace GameFifteenProject.Engine
{
    using System;
    using GameFifteenProject.Contracts.Engine;

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