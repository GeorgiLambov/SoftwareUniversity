namespace BlogSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Migrations;
    using Models;

    public class BlogSystemDbContext : IdentityDbContext<User>, IBlogSystemDbContext
    {
        public BlogSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogSystemDbContext, Configuration>());
        }

        public static BlogSystemDbContext Create()
        {
            return new BlogSystemDbContext();
        }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
