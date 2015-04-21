namespace BugTracker.Data
{
    using System.Data.Entity;

    using BugTracker.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class BugTrackerDbContext : IdentityDbContext<User>
    {
        public BugTrackerDbContext()
            : base("BugTracker")
        {
        }
        
        public static BugTrackerDbContext Create()
        {
            return new BugTrackerDbContext();
        }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
