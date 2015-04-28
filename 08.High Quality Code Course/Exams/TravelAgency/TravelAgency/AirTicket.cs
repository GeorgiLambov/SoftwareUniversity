namespace TravelAgency
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
            : base(from, to, dateTime, price)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber { get; set; }

        public string Airline { get; set; }

        public override TicketType Type
        {
            get { return TicketType.Air; }
        }

        public override string UniqueKey
        {
            get
            {
                return string.Format("{0};;{1}", this.Type, this.FlightNumber);
            }
        }
    }
}
