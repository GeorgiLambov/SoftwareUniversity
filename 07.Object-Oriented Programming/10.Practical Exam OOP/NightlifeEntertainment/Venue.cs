namespace NightlifeEntertainment
{
    using System;
    using System.Collections.Generic;

    public abstract class Venue : IVenue
    {
        private const int MinNumberOfSeats = 10;

        private string name;
        private string location;
        private int numberOfSeats;
        private IList<PerformanceType> allowedTypes;

        public Venue(string name, string location, int numberOfSeats, IList<PerformanceType> allowedTypes)
        {
            this.Name = name;
            this.Location = location;
            this.Seats = numberOfSeats;
            this.AllowedTypes = allowedTypes;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The venue name is required.");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The venue location is required.");
                }

                this.location = value;
            }
        }

        public int Seats
        {
            get
            {
                return this.numberOfSeats;
            }

            private set
            {
                if (value <= MinNumberOfSeats)
                {
                    throw new ArgumentException(string.Format("The seats must be at least {0}.", MinNumberOfSeats));
                }

                this.numberOfSeats = value;
            }
        }

        public IList<PerformanceType> AllowedTypes
        {
            get
            {
                return this.allowedTypes;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The allowed performance types are required.");
                }

                this.allowedTypes = value;
            }
        }
    }
}
