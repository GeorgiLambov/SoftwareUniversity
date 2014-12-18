namespace RestaurantManager.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;  
    using RestaurantManager.Interfaces.Engine;

    public class ConsoleInterface : IUserInterface
    {
        public IEnumerable<string> Input()
        {
            string currentLine = Console.ReadLine();
            while (currentLine != "End")
            {
                yield return currentLine;
                currentLine = Console.ReadLine();
            }
        }

        public void Output(IEnumerable<string> output)
        {
            var result = new StringBuilder();
            foreach (string line in output)
            {
                result.AppendLine(line);
            }

            Console.Write(result.ToString());
        }
    }
}
