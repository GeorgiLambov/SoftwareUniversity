namespace ImportLeaguesAndTeamsFromXML
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using EFMappings;

    class ImportLeaguesTeamsFromXML
    {
 static void Main()
        {
            var inputXml = XDocument.Load("../../leagues-and-teams.xml");
            var xLeagues = inputXml.XPathSelectElements("/leagues-and-teams/league");
            var context = new FootballEntities();
            int leaguesCount = 0;
            foreach (var xLeague in xLeagues)
            {
                Console.WriteLine("Processing league #{0} ...", ++leaguesCount);
                League league = CreateLeagueIfNotExists(context, xLeague);
                var xTeams = xLeague.XPathSelectElements("teams/team");
                CreateTeamsIfNotExists(context, xTeams, league);
                Console.WriteLine();
            }
        }

        private static League CreateLeagueIfNotExists(FootballEntities context, XElement xLeague)
        {
            League league = null;
            var xElementLeagueName = xLeague.Element("league-name");
            if (xElementLeagueName != null)
            {
                string leagueName = xElementLeagueName.Value;
                league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                if (league != null)
                {
                    Console.WriteLine("Existing league: {0}", leagueName);
                }
                else
                {
                    // Create a new league in the DB
                    league = new League() { LeagueName = leagueName };
                    context.Leagues.Add(league);
                    context.SaveChanges();
                    Console.WriteLine("Created league: {0}", leagueName);
                }
            }
            return league;
        }

        private static void CreateTeamsIfNotExists(
           FootballEntities context, IEnumerable<XElement> xTeams, League league)
        {
            foreach (var xTeam in xTeams)
            {
                // Find the team by team name and country name (if exists)
                var teamName = xTeam.Attribute("name").Value;
                var xCountry = xTeam.Attribute("country");
                string countryName = null;
                if (xCountry != null)
                {
                    countryName = xCountry.Value;
                }
                var team = context.Teams
                    .Include(t => t.Leagues)
                    .FirstOrDefault(
                        t => t.TeamName == teamName && 
                        t.Country.CountryName == countryName);

                // Create the team if it does not exists
                if (team != null)
                {
                    Console.WriteLine("Existing team: {0} ({1})",
                        team.TeamName, countryName ?? "no country");
                }
                else
                {
                    // Create a new team in the DB
                    team = new Team()
                    {
                        TeamName = teamName,
                        Country = context.Countries.FirstOrDefault(
                            c => c.CountryName == countryName),
                    };
                    context.Teams.Add(team);
                    context.SaveChanges();
                    Console.WriteLine("Created team: {0} ({1})", 
                        team.TeamName, countryName ?? "no country");
                }

                AddTeamToLeague(context, team, league);
            }
        }

        private static void AddTeamToLeague(FootballEntities context, Team team, League league)
        {
            if (league != null)
            {
                if (team.Leagues.Contains(league))
                {
                    Console.WriteLine("Existing team in league: {0} belongs to {1}",
                        team.TeamName, league.LeagueName);
                }
                else
                {
                    team.Leagues.Add(league);
                    context.SaveChanges();
                    Console.WriteLine("Added team to league: {0} to league {1}",
                        team.TeamName, league.LeagueName);
                }
            }
        }
    }
}
