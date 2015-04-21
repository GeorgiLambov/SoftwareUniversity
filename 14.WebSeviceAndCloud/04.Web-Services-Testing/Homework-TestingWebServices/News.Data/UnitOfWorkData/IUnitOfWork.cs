namespace News.Data.UnitOfWorkData
{
    using Models;
    using Repositories;

    public interface IUnitOfWork
    {
        IRepository<NewsItem> NewsRepository { get; }
        IRepository<User> Users { get; }
        int SaveChages();
    }
}
