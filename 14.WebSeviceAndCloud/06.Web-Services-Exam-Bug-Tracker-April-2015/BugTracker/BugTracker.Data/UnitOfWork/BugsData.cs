namespace BugTracker.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class BugsData : IBugsData
    {
        private readonly BugTrackerDbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        public BugsData()
            : this(new BugTrackerDbContext())
        {
        }

        public BugsData(BugTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Bug> Bugs
        {
            get { return this.GetRepository<Bug>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }


        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
