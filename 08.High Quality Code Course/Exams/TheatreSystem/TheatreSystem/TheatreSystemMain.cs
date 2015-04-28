namespace TheatreSystem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public static class TheatreSystemMain
    {
        private static IPerformanceDatabase performanceDatabase = new PerformanceDatabase();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                if (line != string.Empty)
                {
                    string commandResult = ProcessCommand(line);
                    Console.WriteLine(commandResult);
                }
            }
        }

        private static string ProcessCommand(string line)
        {
            string[] allParameters = line.Split('(');
            string command = allParameters[0];
            string[] parameters = line.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            parameters = parameters.Skip(1).Select(p => p.Trim()).ToArray();

            string commandResult;
            try
            {
                switch (command)
                {
                    case "AddTheatre":
                        commandResult = ExecuteAddTheatreCommand(parameters);
                        break;
                    case "PrintAllTheatres":
                        commandResult = ExecutePrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        commandResult = ExecuteAddPerformanceCommand(parameters);
                        break;
                    case "PrintAllPerformances":
                        commandResult = ExecutePrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        commandResult = ExecutePrintPerformancesCommand(parameters);
                        break;
                    default:
                        commandResult = Constants.InvalidCommand;
                        break;
                }
            }
            catch (Exception ex)
            {
                commandResult = "Error: " + ex.Message;
            }

            return commandResult;
        }

        private static DateTime ParseDateTime(string dateTimeStr)
        {
            var result = DateTime.ParseExact(
                dateTimeStr, Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            return result;
        }

        private static string ExecutePrintPerformancesCommand(string[] parameters)
        {
            string theatre = parameters[0];
            string commandResult;

            var performances = performanceDatabase.ListPerformances(theatre).Select(p =>
            {
                string date = p.StartDateTime.ToString(Constants.DateTimeFormat);
                return string.Format("({0}, {1})", p.PerformanceTitle, date);
            }).ToList();

            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }
            else
            {
                commandResult = Constants.NoPerformancesMsg;
            }

            return commandResult;
        }

        private static string ExecuteAddPerformanceCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            string performanceTitle = parameters[1];
            DateTime startDateTime = ParseDateTime(parameters[2]);
            TimeSpan duration = TimeSpan.Parse(parameters[3]);
            decimal price = decimal.Parse(parameters[4], NumberStyles.Float);
            performanceDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            string commandResult = Constants.PerformanceAddedMsg;
            return commandResult;
        }

        private static string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            performanceDatabase.AddTheatre(theatreName);
            return Constants.TheatreAddedMsg;
        }

        private static string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = performanceDatabase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                performanceDatabase.ListTheatres().ToList().ForEach(t => resultTheatres.AddLast(t));

                return String.Join(", ", resultTheatres);
            }

            return Constants.NoTheatresMsg;
        }

        private static string ExecutePrintAllPerformancesCommand()
        {
            var performances = performanceDatabase.ListAllPerformances().ToList();
            var allPerformances = new StringBuilder();

            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    if (i > 0)
                    {
                        allPerformances.Append(", ");
                    }

                    var date = performances[i].StartDateTime.ToString(Constants.DateTimeFormat);
                    allPerformances.AppendFormat(
                        "({1}, {0}, {2})",
                        performances[i].TheatreName,
                        performances[i].PerformanceTitle,
                        date);
                }

                return allPerformances.ToString();
            }

            return Constants.NoPerformancesMsg;
        }
    }
}
