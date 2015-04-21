using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BugTracker.RestServices.Startup))]

namespace BugTracker.RestServices
{
    using System.Data.Entity;

    using BugTracker.Data;
    using BugTracker.Data.Migrations;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugTrackerDbContext, BugTrackerDbMigrationConfiguration>());
            ConfigureAuth(app);
        }
    }
}
