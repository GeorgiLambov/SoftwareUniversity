namespace RiversByCountryQuery
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using EF_Mappings;

    public class RiversByCountryQuery
    {
        private static void Main()
        {
            var riversQueryXml = XDocument.Load(@"..\..\rivers-query.xml");
            var queryNodes = riversQueryXml.XPathSelectElements("/queries/query");
            var context = new GeographyEntities();
            var allResultsXml = new XElement("results");
            foreach (var queryNode in queryNodes)
            {
                var countries = queryNode.XPathSelectElements("country").Select(c => c.Value);

                // Build the "river names by given countries" query
                var riversQuery = context.Rivers.AsQueryable();
                foreach (var country in countries)
                {
                    riversQuery = riversQuery.Where(
                        r => r.Countries.Any(c => c.CountryName == country));
                }

                riversQuery = riversQuery.OrderBy(r => r.RiverName);
                var riverNamesQuery = riversQuery.Select(r => r.RiverName);

                // Build the query results
                var totalCount = riverNamesQuery.Count();
                var maxResults = queryNode.Attribute("max-results");
                if (maxResults != null)
                {
                    riverNamesQuery = riverNamesQuery.Take(int.Parse(maxResults.Value));
                }
                var riverNames = riverNamesQuery.ToList();
                var listedCount = riverNames.Count();

                // Build the query result XML
                var resultXml = new XElement("rivers",
                    new XAttribute("total-count", totalCount),
                    new XAttribute("listed-count", listedCount),
                    riverNames.Select(river => new XElement("river", river)));

                allResultsXml.Add(resultXml);
            }
            Console.WriteLine(allResultsXml);
        }
    }
}