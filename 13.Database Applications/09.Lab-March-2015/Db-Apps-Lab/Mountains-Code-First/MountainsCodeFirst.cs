namespace Mountains_Code_First
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;

    public class MountainsCodeFirst
    {
        private static void Main()
        {
            // pres Enable-Migrations
            //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            //db.Database.Initialize(true);


            var context = new MountainsContext();

            var bulgaria = new Country { Code = "1S", Name = "Bulagria" };
            var rila = new Mountain { Name = "Rila", Countries = { bulgaria } };
            var musala = new Peak { Name = "Musala", Mountain = rila, Elevation = 2925 };

            context.Countries.Add(bulgaria);
            context.Mountains.Add(rila);
            context.Peaks.Add(musala);
            context.SaveChanges();

            var countriesQuery = context.Countries.Select(c =>
                                new
                                {
                                    ContryName = c.Name,
                                    Mountains = c.Mountains.Select(m =>
                                        new
                                        {
                                            m.Name,
                                            m.Peaks
                                        })
                                });


            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country: " + country.ContryName);
                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("     Mountain: " + mountain.Name);
                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("\t{0} ({1})", peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}


//  List all mountains along with their countries and peaks
//var mountains = context.Mountains.Select(m =>
//    new
//    {
//        m.Name,
//        Countries = m.Countries.Select(c => c.Name),
//        Peaks = m.Peaks.Select(p => new {p.Name, p.Elevation})
//    });


//foreach (var mountain in mountains)
//{
//    Console.WriteLine(
//        "{0}, countries: {1}, peaks: {2}",
//        mountain.Name,
//        string.Join(", ", mountain.Countries),
//        string.Join(", ", mountain.Peaks.Select(
//            p => p.Name + " (elevation " + p.Elevation + ")"))); }