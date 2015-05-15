namespace Mountains_Code_First.Migrations
{
    using System.Data.Entity;

    internal sealed class MountainsMigrationStrategy : DropCreateDatabaseIfModelChanges<MountainsContext>
    {
        protected override void Seed(MountainsContext context)
        {
            var bulgaria = new Country { Code = "BG", Name = "Bulagria" };
            var germany = new Country { Code = "DE", Name = "Germany" };

            var rila = new Mountain { Name = "Rila", Countries = { bulgaria } };
            var pirin = new Mountain { Name = "Pirin", Countries = { bulgaria } };
            var rhodopes = new Mountain { Name = "Rhodopes", Countries = { bulgaria } };

            var musala = new Peak { Name = "Musala", Mountain = rila, Elevation = 2925 };
            var malyovitsa = new Peak { Name = "Malyovitsa", Mountain = rila, Elevation = 2729 };
            var vihren = new Peak { Name = "Vihren", Mountain = pirin, Elevation = 2914 };

            context.Countries.Add(bulgaria);
            context.Countries.Add(germany);

            context.Mountains.Add(rila);
            context.Mountains.Add(pirin);
            context.Mountains.Add(rhodopes);

            context.Peaks.Add(musala);
            context.Peaks.Add(malyovitsa);
            context.Peaks.Add(vihren);

            //context.SaveChanges(); 
            //if (! context.Tablica.Any())
            //{
            //    return;
            //}
        }
    }
}
