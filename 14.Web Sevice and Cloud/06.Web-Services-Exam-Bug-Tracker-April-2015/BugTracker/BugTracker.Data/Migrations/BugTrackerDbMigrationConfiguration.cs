namespace BugTracker.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using BugTracker.Data;

    public sealed class BugTrackerDbMigrationConfiguration : DbMigrationsConfiguration<BugTrackerDbContext>
    {
        public BugTrackerDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BugTrackerDbContext context)
        {
            //  This method will be called after migrating to the latest version
        }
    }
}
