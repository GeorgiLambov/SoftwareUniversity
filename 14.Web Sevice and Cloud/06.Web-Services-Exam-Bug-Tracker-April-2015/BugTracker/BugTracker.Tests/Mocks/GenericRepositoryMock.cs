namespace BugTracker.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BugTracker.Data.Repositories;

    public class GenericRepositoryMock<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private List<TEntity> entities = new List<TEntity>();

        private Func<TEntity, object> keySelector; 

        public bool ChangesSaved { get; set; }

        public GenericRepositoryMock(Func<TEntity, object> keySelector = null)
        {
            if (keySelector != null)
            {
                this.keySelector = keySelector;
            }
            else
            {
                this.keySelector = (u => ((dynamic)u).Id);
            }
        }

        public IQueryable<TEntity> All()
        {
            return this.entities.AsQueryable();
        }

        public TEntity Find(object id)
        {
            return this.entities.FirstOrDefault(entity => id.Equals(this.keySelector(entity)));
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var existingEntity = this.Find(this.keySelector(entity));
            var existingEntityIndex = this.entities.IndexOf(existingEntity);
            this.entities[existingEntityIndex] = entity;
        }

        public void Remove(TEntity entity)
        {
            var existingEntity = this.Find(this.keySelector(entity));
            var existingEntityIndex = this.entities.IndexOf(existingEntity);
            this.entities.RemoveAt(existingEntityIndex);
        }

        public TEntity Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            this.ChangesSaved = true;
        }
    }
}
