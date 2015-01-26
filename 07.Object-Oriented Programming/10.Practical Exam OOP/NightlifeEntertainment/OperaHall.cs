namespace NightlifeEntertainment
{
    using System.Collections.Generic;

    public class OperaHall : Venue
    {
        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre })
        {
        }
    }
}
