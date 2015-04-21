namespace BlogSystem.Data
{
    using Repositories;
    using Models;

    public interface IBlogSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
