using System;
using System.IO;
using System.Linq;

using GeographyMappingsDBFirst;
using System.Web.Script.Serialization;

class ExportRiversAsJson
{
    static void Main()
    {
        var context = new GeographyEntities();
        var rivers = context.Rivers
            .OrderByDescending(r => r.Length)
            .Select(r => new
            {
                riverName = r.RiverName,
                riverLength = r.Length,
                countries = r.Countries
                    .OrderBy(c => c.CountryName)
                    .Select(c => c.CountryName)
            })
            .ToList();
        var jsSerializer = new JavaScriptSerializer();
        var riversJson = jsSerializer.Serialize(rivers);
        File.WriteAllText("rivers.json", riversJson);
        Console.WriteLine(@"Rivers exported to Bin\Debug\rivers.json");
    }
}
