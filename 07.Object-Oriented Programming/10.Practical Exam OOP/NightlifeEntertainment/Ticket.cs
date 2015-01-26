namespace NightlifeEntertainment
{
    using System;
    using System.Text;

    public abstract class Ticket : ITicket
    {
        private decimal price;
        private IPerformance performance;
        private int seat;
        private TicketStatus status;

        public Ticket(IPerformance performance, TicketType type)
        {
            this.Performance = performance;
            this.Price = this.CalculatePrice();
            this.status = TicketStatus.Unsold;
            this.Type = type;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The ticket price must be positive.");
                }

                this.price = value;
            }
        }

        public IPerformance Performance
        {
            get
            {
                return this.performance;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException("The performance is required.");
                }

                this.performance = value;
            }
        }

        public int Seat
        {
            get
            {
                return this.seat;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The seat number must be positive.");
                }

                if (this.Performance == null)
                {
                    throw new InvalidOperationException("The performance must be initialized before assigning a seat.");
                }

                if (value > this.Performance.Venue.Seats)
                {
                    throw new ArgumentException("The seat number must not exceed the capacity of the venue.");
                }

                this.seat = value;
            }
        }

        public TicketStatus Status
        {
            get
            {
                return this.status;
            }
        }

        public TicketType Type { get; private set; }

        public void AssignSeat(int seat)
        {
            this.Seat = seat;
        }

        public void Sell()
        {
            this.status = TicketStatus.Sold;
        }

        public override string ToString()
        {
            var ticket = new StringBuilder();
            ticket.AppendFormat("{0} {1} {0}", new string('=', 5), this.Performance.Name).AppendLine()
                .AppendFormat("At {0} ({1})", this.Performance.Venue.Name, this.Performance.Venue.Location).AppendLine()
                .AppendFormat("On {0}", this.Performance.StartTime).AppendLine()
                .AppendFormat("Seat: {0}", this.Seat).AppendLine()
                .AppendFormat("Price: ${0:F2}", this.Price).AppendLine()
                .AppendLine(new string('=', 15));

            return ticket.ToString();
        }

        protected virtual decimal CalculatePrice()
        {
            if (this.Performance == null)
            {
                throw new ArgumentException("The price cannot be calculated because there is no performance for this ticket.");
            }

            return this.Performance.BasePrice;
        }
    }
}
