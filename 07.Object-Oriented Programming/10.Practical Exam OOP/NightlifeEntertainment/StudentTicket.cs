namespace NightlifeEntertainment
{
    using System;

    public class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            var studentPrice = base.CalculatePrice() * 80 / 100;
            return studentPrice;
        }
    }
}