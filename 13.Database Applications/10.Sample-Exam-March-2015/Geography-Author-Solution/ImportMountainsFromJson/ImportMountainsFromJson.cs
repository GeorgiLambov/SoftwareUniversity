using System;
using System.IO;
using System.Linq;

using MountainsCodeFirst;

using Newtonsoft.Json.Linq;

class ImportMountainsFromJson
{
    static void Main()
    {
        string mountainsJson = File.ReadAllText("../../mountains.json");
        var mountains = JArray.Parse(mountainsJson);
        foreach (var mountain in mountains)
        {
            try
            {
                ImportMountain(mountain);
                Console.WriteLine("Mountain {0} imported", mountain["mountainName"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    private static void ImportMountain(JToken mountainObj)
    {
        var context = new MountainsContext();
        var mountain = new Mountain();
        
        // Parse mountain
        if (mountainObj["mountainName"] == null)
        {
            throw new Exception("Missing mountain name");
        }
        mountain.Name = mountainObj["mountainName"].Value<string>();

        // Parse peaks
        var peaks = mountainObj["peaks"];
        if (peaks != null)
        {
            foreach (var peak in peaks)
            {
                if (peak["peakName"] == null)
                {
                    throw new Exception("Missing peak name");
                }
                string peakName = peak["peakName"].Value<string>();

                if (peak["elevation"] == null)
                {
                    throw new Exception("Missing peak elevation");
                }
                int elevation = peak["elevation"].Value<int>();

                mountain.Peaks.Add(new Peak() { Name = peakName, Elevation = elevation});
            }
        }

        // Parse countries
        var countryNames = mountainObj["countries"];
        if (countryNames != null)
        {
            foreach (var countryName in countryNames)
            {
                var countryCode = 
                    new string(countryName.Value<string>().Take(2).ToArray()).ToUpper();
                var country = context.Countries.Find(countryCode);
                if (country == null)
                {
                    country = new Country() { Code = countryCode, Name = countryName.Value<string>() };
                }
                mountain.Countries.Add(country);
            }
        }

        // Persist the mountain in the database
        context.Mountains.Add(mountain);
        context.SaveChanges();
    }
}
