namespace _01.GalacticGPS
{
    using System;

    public class GalacticGPS
    {
        public static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Location ddd = new Location();
            Console.WriteLine(home);
            Console.WriteLine(ddd);
            home.Planet = (Planet)Enum.Parse(typeof(Planet), "Mars");
            Console.WriteLine(home);
        }
    }
}
