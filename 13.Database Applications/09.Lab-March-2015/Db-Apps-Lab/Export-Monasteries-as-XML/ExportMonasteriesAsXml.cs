namespace Export_Monasteries_as_XML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using EF_Mappings;

    public class ExportMonasteriesAsXml
    {
        public static void Main()
        {
            var context = new GeographyEntities();
            var countries = context.Countries;

            var countriesQuery = countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries
                        .OrderBy(m => m.Name)
                        .Select(m => m.Name)
                });

            // Build the output XML
            var xmlMonasteries = new XElement("monasteries");
            foreach (var country in countriesQuery)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));

                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }

                xmlMonasteries.Add(xmlCountry);
            }
            Console.WriteLine(xmlMonasteries);

            var xmlDoc = new XDocument(xmlMonasteries);
            xmlDoc.Save(@"..\..\monasteries.xml");
        }
    }
}
