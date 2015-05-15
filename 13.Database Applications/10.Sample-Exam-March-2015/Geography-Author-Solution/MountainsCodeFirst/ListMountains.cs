namespace MountainsCodeFirst
{
    using System;
    using System.Linq;

    public class ListMountains
    {
        static void Main()
        {
            var context = new MountainsContext();
            var mountains = context.Mountains.Select(m =>
                new
                {
                    m.Name,
                    Countries = m.Countries.Select(c => c.Name),
                    Peaks = m.Peaks.Select(p => new { p.Name, p.Elevation })
                });
            foreach (var mountain in mountains)
            {
                Console.WriteLine(
                    "{0}, countries: {1}, peaks: {2}",
                    mountain.Name,
                    string.Join(", ", mountain.Countries),
                    string.Join(", ", mountain.Peaks.Select(
                        p => p.Name + " (elevation " + p.Elevation + ")")));
            }
        }
    }
}
