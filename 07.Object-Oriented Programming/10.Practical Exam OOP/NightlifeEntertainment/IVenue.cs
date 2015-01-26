namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;

    public interface IVenue
    {
        string Name { get; }

        string Location { get; }

        int Seats { get; }

        IList<PerformanceType> AllowedTypes { get; }
    }
}
