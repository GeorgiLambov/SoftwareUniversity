namespace Mountains_Code_First.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    // Primeren config klas suzdava se avtomatichno s Enable-Migrations.
    // v main 
    // Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
    // db.Database.Initialize(true);  
         
    internal sealed class Configuration : DbMigrationsConfiguration<MountainsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MountainsContext context)
        {
            // Seed data if not already seeded
            var bulgaria = new Country { Code = "BG", Name = "Bulgaria" };
            context.Countries.Add(bulgaria);
            var germany = new Country { Code = "DE", Name = "Germany" };
            context.Countries.Add(germany);

            var rila = new Mountain { Name = "Rila", Countries = { bulgaria } };
            context.Mountains.Add(rila);
            var pirin = new Mountain { Name = "Pirin", Countries = { bulgaria } };
            context.Mountains.Add(pirin);
            var rhodopes = new Mountain { Name = "Rhodopes", Countries = { bulgaria } };
            context.Mountains.Add(rhodopes);

            var musala = new Peak { Name = "Musala", Elevation = 2925, Mountain = rila };
            context.Peaks.Add(musala);
            var malyovitsa = new Peak { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
            context.Peaks.Add(malyovitsa);
            var vihren = new Peak { Name = "Vihren", Elevation = 2914, Mountain = pirin };
            context.Peaks.Add(vihren);
        }
    }
}
