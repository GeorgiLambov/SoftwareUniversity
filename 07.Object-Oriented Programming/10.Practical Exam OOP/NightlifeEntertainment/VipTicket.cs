namespace NightlifeEntertainment
{
    using System;

    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            var vipPrice = base.CalculatePrice() * 1.5m;
            return vipPrice;
        }
    }
}