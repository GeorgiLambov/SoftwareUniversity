namespace BugTracker.Data.UnitOfWork
{
    using Models;
    using Repositories;

    public interface IBugsData
    {
        IRepository<User> Users { get; }

        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}
