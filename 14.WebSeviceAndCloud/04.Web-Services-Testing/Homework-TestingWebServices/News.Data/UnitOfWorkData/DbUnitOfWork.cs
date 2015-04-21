namespace News.Data.UnitOfWorkData
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class DbUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public DbUnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public DbUnitOfWork()
            : this(new ApplicationDbContext())
        {
        }

        public IRepository<NewsItem> NewsRepository
        {
            get { return this.GetRepository<NewsItem>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public int SaveChages()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfRepository, Activator.CreateInstance(newRepository, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
