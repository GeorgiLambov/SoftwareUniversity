namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CinemaEngine
    {
        private StringBuilder output;

        protected IList<IVenue> venues;
        protected IList<IPerformance> performances;

        public CinemaEngine()
        {
            this.output = new StringBuilder();
            this.Venues = new List<IVenue>();
            this.Performances = new List<IPerformance>();
        }

        public StringBuilder Output
        {
            get
            {
                return this.output;
            }
        }

        protected IList<IVenue> Venues
        {
            get { return this.venues; }
            private set { this.venues = value; }
        }

        protected IList<IPerformance> Performances
        {
            get { return this.performances; }
            private set { this.performances = value; }
        }

        public void ParseCommand(string command)
        {
            string[] commandWords = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                this.DispatchCommand(commandWords);
            }
            catch (Exception e)
            {
                this.Output.AppendLine(e.Message);
            }
        }

        protected virtual void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "venue":
                    this.ExecuteInsertVenueCommand(commandWords);
                    break;
                case "performance":
                    this.ExecuteInsertPerformanceCommand(commandWords);
                    break;
                default:
                    break;
            }
        }

        protected virtual void ExecuteSellTicketCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var type = (TicketType)Enum.Parse(typeof(TicketType), commandWords[2], true);
            this.output.Append(performance.SellTicket(type));
        }

        protected virtual void ExecuteReportCommand(string[] commandWords)
        {
            throw new NotImplementedException();
        }

        protected virtual void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "regular":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new RegularTicket(performance));
                    }

                    break;
                default:
                    break;
            }
        }

        protected virtual void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "cinema":
                    var cinema = new Cinema(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(cinema);
                    break;
                default:
                    break;
            }
        }

        protected virtual void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "movie":
                    var venue = this.GetVenue(commandWords[5]);
                    var movie = new Movie(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(movie);
                    break;
                default:
                    break;
            }
        }

        protected IVenue GetVenue(string name)
        {
            var venue = this.Venues.FirstOrDefault(v => v.Name == name);
            if (venue == null)
            {
                throw new InvalidOperationException("There is no venue with the given name in the database.");
            }

            return venue;
        }

        protected IPerformance GetPerformance(string name)
        {
            var performance = this.Performances.FirstOrDefault(v => v.Name == name);
            if (performance == null)
            {
                throw new InvalidOperationException("There is no performance with the given name in the database.");
            }

            return performance;
        }

        protected virtual void ExecuteFindCommand(string[] commandWords)
        {
            throw new NotImplementedException();
        }

        private void DispatchCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "insert":
                    this.ExecuteInsertCommand(commandWords);
                    break;
                case "supply_tickets":
                    this.ExecuteSupplyTicketsCommand(commandWords);
                    break;
                case "sell_ticket":
                    this.ExecuteSellTicketCommand(commandWords);
                    break;
                case "report":
                    this.ExecuteReportCommand(commandWords);
                    break;
                case "find":
                    this.ExecuteFindCommand(commandWords);
                    break;
                default:
                    break;
            }
        }
    }
}
