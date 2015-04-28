namespace TestingRepositories
{
    using System;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using News.Data;
    using News.Data.Repositories;
    using News.Data.UnitOfWorkData;
    using News.Models;

    [TestClass]
    public class CrudTests
    {
        private IUnitOfWork data;
        private IRepository<NewsItem> repository;

        // private static TransactionScope tran;

        public CrudTests()
        {
            this.data = new DbUnitOfWork(new ApplicationDbContext());
            this.repository = this.data.NewsRepository;
        }

        [TestInitialize]
        public void TestInit()
        {
            foreach (var newsItem in repository.All())
            {
                this.repository.Delete(newsItem);
            }

            this.repository.SaveChanges();

            // Start a new temporary transaction
            // tran = new TransactionScope();
        }

        //[TestCleanup]
        //public void TestCleanUp()
        //{
        //    // Rollback the temporary transaction
        //    tran.Dispose();
        //}

        [TestMethod]
        public void ListAllNewsItem_ShouldReturnEmptyList()
        {
            Assert.AreEqual(0, this.repository.All().Count());
        }

        [TestMethod]
        public void ListAllNewsItem_ShouldReturnListWithTwoMembers()
        {
            this.repository.Add(new NewsItem
            {
                Title = "Nov",
                Content = "Nov Nov Content",
                PublishDate = DateTime.Now
            });

            this.repository.Add(new NewsItem
            {
                Title = "222222",
                Content = "22222222222222222",
                PublishDate = DateTime.Now.AddDays(-1)
            });

            this.repository.SaveChanges();

            Assert.AreEqual(2, this.repository.All().Count());
        }

        [TestMethod]
        public void AddNewsItem_ThenGetTheNewItem_SouldBeTheSame()
        {
            var news = (new NewsItem
            {
                Title = "novaa",
                Content = "novavvav",
                PublishDate = DateTime.Now
            });

            this.repository.Add(news);
            this.repository.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = this.repository.GetById(news.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(news.Content, newsFromDb.Content);
            Assert.AreEqual(news.Title, newsFromDb.Title);
            Assert.AreEqual(news.PublishDate, newsFromDb.PublishDate);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        // Content field is mandatory
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNewsItemWithoutContentData_ShouldThrowException()
        {
            this.repository.Add(new NewsItem
            {
                Title = "Noavava",
                PublishDate = DateTime.Now
            });

            this.repository.SaveChanges();
        }

        // Title field is mandatory
        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void CreateNewsItemWithoutTitleData_ShouldThrowException()
        {
            this.repository.Add(new NewsItem
            {
                Content = "Noavavav",
                PublishDate = DateTime.Now
            });

            this.repository.SaveChanges();
        }

        [TestMethod]
        public void ModifyExistingNewsItem_WithValidData()
        {
            var news = (new NewsItem
            {
                Title = "Taralala",
                Content = "Lalalalalala",
                PublishDate = DateTime.Now
            });

            this.repository.Add(news);
            this.repository.SaveChanges();

            var existingNews = this.repository.All().FirstOrDefault();
            existingNews.Title = "New title";
            this.repository.Update(news);
            this.repository.SaveChanges();

            var itemAfterChange = this.repository.GetById(existingNews.Id);

            Assert.AreEqual("New title", itemAfterChange.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ModifyExistingNewsItem_WithInvalidData_ShouldThrowException()
        {
            var news = (new NewsItem
            {
                Title = "Taralala",
                Content = "Lalalalalala",
                PublishDate = DateTime.Now
            });

            this.repository.Add(news);
            this.repository.SaveChanges();

            var existingNews = this.repository.All().FirstOrDefault();
            existingNews.Content = "";
            this.repository.Update(news);
            this.repository.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ModifyUnExistingNewsItem_ShouldThrowException()
        {
            var unexistingNews = this.repository.GetById(1);
            unexistingNews.Title = "New";
            this.repository.Update(unexistingNews);
            this.repository.SaveChanges();
        }

        [TestMethod]
        public void DeleteExistingNewsItem()
        {
            var news = (new NewsItem
            {
                Title = "Taralala",
                Content = "Lalalalalala",
                PublishDate = DateTime.Now
            });

            this.repository.Add(news);
            this.repository.SaveChanges();

            var existingNews = this.repository.All().FirstOrDefault();
            this.repository.Delete(existingNews);
            this.repository.SaveChanges();

            Assert.AreEqual(0, this.repository.All().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteUnExistingNewsItem_ShouldThrowException()
        {
            this.repository.Delete(1);
            this.repository.SaveChanges();
        }
    }
}
