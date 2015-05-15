using System;
using System.Linq;
using System.Xml.Linq;

using GeographyMappingsDBFirst;

class ExportMonasteriesAsXml
{
    static void Main()
    {
        var context = new GeographyEntities();
        var countries = context.Countries
            .OrderBy(c => c.CountryName)
            .Select(c => new
            {
                c.CountryName,
                Monasteries = c.Monasteries
                    .OrderBy(m => m.Name)
                    .Select(m => m.Name)
            });
        var xmlRoot = new XElement("monasteries");
        foreach (var country in countries)
        {
            if (country.Monasteries.Any())
            {
                var countryXml = new XElement("country",
                    new XAttribute("name", country.CountryName));
                foreach (var monastery in country.Monasteries)
                {
                    var monasteryXml = new XElement("monastery", monastery);
                    countryXml.Add(monasteryXml);
                }
                xmlRoot.Add(countryXml);
            }
        }
        var xmlDoc = new XDocument(xmlRoot);
        xmlDoc.Save("monasteries.xml");
        Console.WriteLine(@"Monasteries exported to Bin\Debug\monasteries.xml");
    }
}
