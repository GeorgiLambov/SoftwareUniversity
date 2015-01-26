namespace TheatreSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> sortedSetPerformances =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.sortedSetPerformances.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException(Constants.DuplicateTheatreMsg);
            }

            this.sortedSetPerformances[theatreName] = new SortedSet<Performance>();
        }

        public int GetPerformancesCount(string theatreName)
        {
            return this.sortedSetPerformances[theatreName].Count();
        }

        public int GetTheatresCount()
        {
            return this.sortedSetPerformances.Count();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.sortedSetPerformances.Keys;
            return theatres;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.sortedSetPerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreDoesNotExistMsg);
            }

            var performances = this.sortedSetPerformances[theatreName];
            var endDateTime = startDateTime + duration;
            if (IsOverlap(performances, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException(Constants.TimeOverlapMsg);
            }

            var performance = new Performance(theatreName, performanceTitle, startDateTime, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.sortedSetPerformances.Keys;
            var allPerformances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performances = this.sortedSetPerformances[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.sortedSetPerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.NoTheatreMsg);
            }

            var theatrePerformances = this.sortedSetPerformances[theatreName];
            return theatrePerformances;
        }

        private static bool IsOverlap(IEnumerable<Performance> performances, DateTime startDateTime, DateTime endDateTime)
        {
            foreach (var otherPerfotmance in performances)
            {
                var otherStartTime = otherPerfotmance.StartDateTime;
                var otherEndTime = otherPerfotmance.StartDateTime + otherPerfotmance.Duration;

                var isOverlap =
                    (otherStartTime < startDateTime && otherEndTime < startDateTime) ||
                    (endDateTime < otherStartTime && endDateTime < otherEndTime);

                if (!isOverlap)
                {
                    return true;
                }
            }

            return false;
        }
    }
}