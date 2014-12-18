using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Program
    {
        private static Engine GetEngineInstance()
        {
            return new ExtendedEngine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
