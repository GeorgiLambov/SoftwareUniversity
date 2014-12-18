using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Program
    {
        static void Main(string[] args)
        {
            HoldingPen pen = InitializePen();
            StartOperations(pen);
        }

        private static void StartOperations(HoldingPen pen)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                pen.ParseCommand(input);
                input = Console.ReadLine();
            }
        }

        private static HoldingPen InitializePen()
        {
            return new InfestationPen();
        }
    }
}
