using System;
using TheSlum.GameEngine;

namespace TheSlum
{
    public class Program
    {
        static Engine GetEngineInstance()
        {
            return new ExtendedEngine();
        }
        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();
            engine.Run();
        }
    }
}
