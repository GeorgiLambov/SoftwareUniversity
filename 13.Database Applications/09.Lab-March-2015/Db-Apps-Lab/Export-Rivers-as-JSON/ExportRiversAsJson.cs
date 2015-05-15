namespace Export_Rivers_as_JSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;   //System.Web.Extensions.dll:
    using EF_Mappings;

    public class ExportRiversAsJson
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers;

            var riversQuery = rivers
                    .OrderByDescending(r => r.Length)
                    .Select(r => new
                    {
                        riverName = r.RiverName,
                        riverLength = r.Length,
                        countries = r.Countries
                                    .OrderBy(c => c.CountryName)
                                    .Select(c => c.CountryName)
                    });

            var jsSerializer = new JavaScriptSerializer();
            var riversJson = jsSerializer.Serialize(riversQuery);

            File.WriteAllText(@"../../rivers.json", riversJson);
            Console.WriteLine(@"Rivers exported to rivers.json");
        }
    }
}
