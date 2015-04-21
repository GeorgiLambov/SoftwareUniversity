namespace News.Controllers.TestWithMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Data.Repositories;
    using Models;

    public class RepositoryMock : IRepository<NewsItem>
    {
        public IList<NewsItem> Entities { get; set; }

        public RepositoryMock()
        {
            this.Entities = new List<NewsItem>();
        }

        public IQueryable<NewsItem> All()
        {
            return this.Entities.AsQueryable();
        }

        public NewsItem Add(NewsItem entity)
        {
            this.Entities.Add(entity);
            return entity;
        }

        public NewsItem GetById(object id)
        {
            var entity = this.All().FirstOrDefault(b => b.Id == (int)id);
            return entity;
        }

        public NewsItem Delete(NewsItem newsItem)
        {
            this.Entities.Remove(newsItem);
            return newsItem;
        }

        public NewsItem Delete(object id)
        {
            var newsItem = this.Entities.FirstOrDefault(e => e.Id == (int)id);
            this.Delete(newsItem);
            return newsItem;
        }

        public void Detach(NewsItem entity)
        {
            throw new NotImplementedException();
        }

        public NewsItem Update(NewsItem entity)
        {
            var newsItem = this.Entities.FirstOrDefault(e => e.Id == entity.Id);
            if (newsItem != null)
            {
                newsItem = entity;
            }

            return newsItem;
        }

        public int SaveChanges()
        {
            return 1; // todo
        }
    }
}
