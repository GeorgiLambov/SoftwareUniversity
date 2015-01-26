namespace TheatreSystem
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.PerformanceTitle = performanceTitle;
            this.StartDateTime = startDateTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName { get; private set; }

        public string PerformanceTitle { get; private set; }

        public DateTime StartDateTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; private set; }

        public int CompareTo(Performance otherPerformance)
        {
            int resultOfCompare = this.StartDateTime.CompareTo(otherPerformance.StartDateTime);
            return resultOfCompare;
        }
    }
}