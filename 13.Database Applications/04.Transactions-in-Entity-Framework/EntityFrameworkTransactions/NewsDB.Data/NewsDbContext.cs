namespace NewsDB.Data
{
    using System.Data.Entity;
    using NewsDB.Model;

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("NewsDB")
        {
        }

        public IDbSet<News> News { get; set; }
    }
}
