namespace ExportLeaguesAndTeamsAsJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using EFMappings;

    class ExportLeaguesAndTeamsAsJSON
    {
        static void Main()
        {
            var context = new FootballEntities();
            var leagues = context.Leagues;

            var leaguesQuery = leagues
                    .OrderBy(l => l.LeagueName)
                    .Select(l => new
                    {
                        leagueName = l.LeagueName,
                        teams = l.Teams
                                      .OrderBy(t => t.TeamName)
                                      .Select(t => t.TeamName)
                    });

            var jsSerializer = new JavaScriptSerializer();
            var leaguesJson = jsSerializer.Serialize(leaguesQuery);

            File.WriteAllText(@"../../leagues-and-teams.json", leaguesJson);
            Console.WriteLine(@"Leagues exported to leagues-and-teams.json");
        }
    }
}
