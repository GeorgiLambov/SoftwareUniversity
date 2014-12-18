using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Estates.Data;
using Estates.Interfaces;

namespace Estates.Engine
{
    class EstatesAgency
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IEstateEngine estateEngine = EstateFactory.CreateEstateEngine();

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null || commandLine == "end")
                {
                    // End of command sequence reached
                    break;
                }
                if (commandLine != "")
                {
                    string[] commandTokens = commandLine.Split(' ');
                    string cmd = commandTokens[0];
                    string[] cmdArgs = (commandTokens.Skip(1)).ToArray();
                    string cmdResult = estateEngine.ExecuteCommand(cmd, cmdArgs);
                    Console.WriteLine(cmdResult);
                }
            }
        }
    }
}
