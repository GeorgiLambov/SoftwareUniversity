

namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public sealed class ExtendedEngine : CinemaEngine
    {
        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }

                    break;
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sports = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sports);
                    break;
                case "concert_hall":
                    var concert = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concert);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "theatre":
                    var theatreVenue = this.GetVenue(commandWords[5]);
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), theatreVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concertVenue = this.GetVenue(commandWords[5]);
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), concertVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var tickets = performance.Tickets.Where(t => t.Status == TicketStatus.Sold);
            var enumerable = tickets as ITicket[] ?? tickets.ToArray();
            var totalPrice = enumerable.Sum(t => t.Price);

            this.Output.AppendFormat("{0}: {1} ticket(s), total: ${2:F}",
                performance.Name, enumerable.Count(), totalPrice).AppendLine()
                .AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location).AppendLine()
                .AppendFormat("Start time: {0}", performance.StartTime).AppendLine();
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string word = commandWords[1];
            DateTime startSearchTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            var matchedPerformances = SearchForPerformances(word, startSearchTime);

            var matchedVenues = this.venues
                .Where(v => v.Name.ToLower().Contains(word.ToLower()))
                .OrderBy(v => v.Name);

            this.Output.AppendFormat("Search for \"{0}\"", word).AppendLine();
            this.Output.AppendLine("Performances:");

            if (matchedPerformances.Any())
            {
                this.Output.AppendLine(string.Join(Environment.NewLine, matchedPerformances.Select(p => "-" + p.Name)));
            }
            else
            {
                this.Output.AppendLine("no results");
            }

            this.Output.AppendLine("Venues:");
            if (matchedVenues.Any())
            {

                foreach (var venue in matchedVenues)
                {
                    this.Output.AppendFormat("-{0}", venue.Name).AppendLine();
                    var performances = SearchForPerformances(venue.Name, startSearchTime, true);
                    if (performances.Any())
                    {
                        foreach (var performance in performances)
                        {
                            this.Output.AppendFormat("--{0}", performance.Name).AppendLine();
                        }
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }

        private IEnumerable<IPerformance> SearchForPerformances(string word, DateTime startSearchTime, bool searchForVenues = false)
        {
            var matchedPerformances = this.performances.AsEnumerable();
            if (searchForVenues)
            {
                matchedPerformances = matchedPerformances
                    .Where(v => v.Venue.Name.ToLower() == word.ToLower());
            }
            else
            {
                matchedPerformances = matchedPerformances
                    .Where(p => p.Name.ToLower().Contains(word.ToLower()));
            }

            matchedPerformances = matchedPerformances
                .Where(p => p.StartTime >= startSearchTime)
                .OrderBy(p => p.StartTime)
                .ThenByDescending(p => p.BasePrice)
                .ThenBy(p => p.Name);
            return matchedPerformances;
        }
    }
}
