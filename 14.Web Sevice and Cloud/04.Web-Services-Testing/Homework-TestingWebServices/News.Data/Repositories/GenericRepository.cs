namespace News.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext context;
        private IDbSet<T> set;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }
        public IDbSet<T> Set
        {
            get { return this.set; }
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this.set.Where(expression).AsQueryable();
        }

        public T GetById(object id)
        {
            return this.set.Find(id);
        }

        public T Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            return entity;
        }

        public T Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            return entity;
        }

        public T Delete(object id)
        {
            var entity = this.GetById(id);
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
