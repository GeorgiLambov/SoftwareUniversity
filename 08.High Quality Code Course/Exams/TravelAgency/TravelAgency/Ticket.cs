namespace TravelAgency
{
    using System;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(string from, string to, DateTime dateTime, decimal price)
        {
            this.From = from;
            this.To = to;
            this.DateTime = dateTime;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public string From { get; set; }

        public string To { get; set; }

        public DateTime DateTime { get; set; }

        public decimal Price { get; set; }

        public abstract string UniqueKey { get; }

        public override string ToString()
        {
            string result = string.Format(
                "[{0}; {1}; {2}]", 
                this.DateTime.ToString(Constants.DateTimeFormat),
                this.Type.ToString().ToLower(),
                string.Format(Constants.NumberFormat, this.Price));
            return result;
        }

        public int CompareTo(Ticket otherTicket)
        {
            int resultOfCompare = this.DateTime.CompareTo(otherTicket.DateTime);
            if (resultOfCompare == 0)
            {
                resultOfCompare = ((int)this.Type).CompareTo((int)otherTicket.Type);
            }

            if (resultOfCompare == 0)
            {
                resultOfCompare = this.Price.CompareTo(otherTicket.Price);
            }

            return resultOfCompare;
        }
    }
}
