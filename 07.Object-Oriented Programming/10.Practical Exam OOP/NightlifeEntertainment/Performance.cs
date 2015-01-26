namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Performance : IPerformance
    {
        private string name;
        private decimal basePrice;
        private IVenue venue;
        private IList<ITicket> tickets;

        public Performance(string name, decimal basePrice, IVenue venue, DateTime startTime, PerformanceType type)
        {
            this.Name = name;
            this.BasePrice = basePrice;
            this.Venue = venue;
            this.ValidateVenue();
            this.StartTime = startTime;
            this.Type = type;
            this.tickets = new List<ITicket>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The performance name is required.");
                }

                this.name = value;
            }
        }

        public decimal BasePrice
        {
            get
            {
                return this.basePrice;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The performance base price should be positive.");
                }

                this.basePrice = value;
            }
        }

        public IVenue Venue
        {
            get
            {
                return this.venue;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("The performance venue should be positive.");
                }

                this.venue = value;
            }
        }

        public DateTime StartTime { get; protected set; }

        public PerformanceType Type { get; protected set; }

        public IList<ITicket> Tickets
        {
            get
            {
                return this.tickets;
            }
        }

        public void AddTicket(ITicket ticket)
        {
            if (this.tickets.Count == this.Venue.Seats)
            {
                throw new InvalidOperationException("There are no seats left for this performance.");
            }

            ticket.AssignSeat(this.tickets.Count + 1);
            this.tickets.Add(ticket);
        }

        public string SellTicket(TicketType type)
        {
            var ticket = this.tickets.FirstOrDefault(t => t.Status == TicketStatus.Unsold && t.Type == type);
            if (ticket == null)
            {
                throw new ArgumentException("There is no unsold ticket of the specified type.");
            }

            ticket.Sell();
            return ticket.ToString();
        }

        protected abstract void ValidateVenue();
    }
}
