namespace EFMappings
{
    using System;

    class ListTeamsNames
    {
        static void Main()
        {
            var context = new FootballEntities();
            foreach (var team in context.Teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
