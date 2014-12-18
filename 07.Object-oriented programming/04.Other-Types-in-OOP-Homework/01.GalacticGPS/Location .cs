namespace _01.GalacticGPS
{
    using System;

    public struct Location
    {
        // define fields for the struct
        private double latitude;
        private double longitude;
        private Planet planet;

        // define a constructor 
        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        // define properties for the structure
        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException(Convert.ToString(value), "Latitude should be in the range [0..90]");
                }

                this.latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }

            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException(Convert.ToString(value), "Longitude should be in the range [0..90]");
                }

                this.longitude = value;
            }
        }

        public Planet Planet
        {
            get { return this.planet; }
            set { this.planet = value; }
        }

        ////ToString method to print the location on the console
        public override string ToString()
        {
            return string.Format("{0:F6} - {1:F6} - {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}