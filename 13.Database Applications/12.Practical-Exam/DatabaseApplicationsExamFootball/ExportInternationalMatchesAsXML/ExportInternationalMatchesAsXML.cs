namespace ExportInternationalMatchesAsXML
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using EFMappings;

    class ExportInternationalMatchesAsXML
    {
        static void Main()
        {
            // Ensure date formatting will use the English names
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var context = new FootballEntities();
            var matches = context.InternationalMatches;

            var matchesQuery = matches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry.CountryName)
                .ThenBy(m => m.AwayCountry.CountryName)
                .Select(m => new
                {
                    dateTime = m.MatchDate,
                    homeCountryName = m.HomeCountry.CountryName,
                    homeCountryCode = m.HomeCountryCode,
                    awayCountryName = m.AwayCountry.CountryName,
                    awayCountryCode = m.AwayCountryCode,
                    homeGoals = m.HomeGoals,
                    awayGoals = m.AwayGoals,
                    leagueName = m.League.LeagueName
                });

            // Build the output XML
            var xmlMatches = new XElement("matches");
            foreach (var match in matchesQuery)
            {
                var xmlMatch = new XElement("match");
                if (match.dateTime != null)
                {
                    if (match.dateTime.Value.TimeOfDay == TimeSpan.Zero)
                    {
                        string date = match.dateTime.Value.ToString("dd-MMM-yyyy");
                        xmlMatch.Add(new XAttribute("date-time", date));
                    }
                    else
                    {
                        string dateTime = match.dateTime.Value.ToString("dd-MMM-yyyy hh:mm");
                        xmlMatch.Add(new XAttribute("date-time", dateTime));
                    }
                }

                var xmlHomeCountry = new XElement("home-country", match.homeCountryName);
                xmlHomeCountry.Add(new XAttribute("code", match.homeCountryCode));
                xmlMatch.Add(xmlHomeCountry);

                var xmlAwayCountry = new XElement("away-country", match.awayCountryName);
                xmlAwayCountry.Add(new XAttribute("code", match.awayCountryCode));
                xmlMatch.Add(xmlAwayCountry);

                if (match.homeGoals != null && match.awayGoals != null)
                {
                    xmlMatch.Add(new XElement("score", match.homeGoals + "-" + match.awayGoals));
                }
                if (match.leagueName != null)
                {
                    xmlMatch.Add(new XElement("league", match.leagueName));
                }

                xmlMatches.Add(xmlMatch);
            }
            Console.WriteLine(xmlMatches);

            var xmlDoc = new XDocument(xmlMatches);
            xmlDoc.Save(@"..\..\international-matches.xml ");
        }
    }
}
