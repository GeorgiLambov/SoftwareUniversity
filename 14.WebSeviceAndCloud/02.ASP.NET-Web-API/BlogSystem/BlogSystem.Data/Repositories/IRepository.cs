namespace BlogSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T GetById(object id);

        T Add(T entity);

        T Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        void Detach(T entity);

        int SaveChanges();
    }
}
