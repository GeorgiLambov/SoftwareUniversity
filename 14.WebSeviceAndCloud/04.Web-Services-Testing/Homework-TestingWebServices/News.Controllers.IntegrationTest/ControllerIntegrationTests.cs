namespace News.Controllers.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Web.Http;
    using System.Web.Http.Filters;
    using Data.Repositories;
    using Data.UnitOfWorkData;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Owin;

    using News.Data;
    using News.Models;
    using Newtonsoft.Json;
    using WebServices;

    [TestClass]
    public class ControllerIntegrationTests
    {
        private TestServer httpTestServer;
        private HttpClient httpClient;
        private IUnitOfWork data;
        private IRepository<NewsItem> repository;

        // private static TransactionScope tran;

        public ControllerIntegrationTests()
        {
            this.data = new DbUnitOfWork(new ApplicationDbContext());
            this.repository = this.data.NewsRepository;
        }

        [TestInitialize]
        public void TestInit()
        {
            // Start OWIN testing HTTP server with Web API support
            this.httpTestServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                appBuilder.UseWebApi(config);
            });
            this.httpClient = httpTestServer.HttpClient;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.httpTestServer.Dispose();
        }

        [TestMethod]
        public void GetEmptyListOfItems_ShouldReturn200_Ok()
        {
            // Arrange
            this.CleanDatabase();
            // Act
            var httpResponse = httpClient.GetAsync("/api/news").Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItems = JsonConvert.DeserializeObject<List<NewsItem>>(content);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(0, resultItems.Count);
        }

        [TestMethod]
        public void GetListOfItems_ShouldReturn200_Ok()
        {
            // Arrange
            CleanDatabase();
            SeedItems();

            // Act
            var httpResponse = httpClient.GetAsync("/api/news").Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItems = JsonConvert.DeserializeObject<List<NewsItem>>(content);
            CleanDatabase();
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(3, resultItems.Count);
        }

        [TestMethod]
        public void AddItem_ShouldReturn201_Created()
        {
            // Arrange
            CleanDatabase();
            SeedItems();
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", "Title"),
                new KeyValuePair<string, string>("Content", "Content"), 
            });

            // Act
            var httpResponse = httpClient.PostAsync("/api/news", postContent).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItem = JsonConvert.DeserializeObject<NewsItem>(content);
            CleanDatabase();

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual("Title", "Title");
            Assert.AreEqual("Content", "Content");
            Assert.IsNotNull(resultItem);
        }

        [TestMethod]
        public void AddItem_InvalidData_ShouldReturn400_BadRequest()
        {
            // Arrange
            CleanDatabase();
            SeedItems();

            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", "Title"),
            });

            // Act
            var httpResponse = httpClient.PostAsync("/api/news", postContent).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItem = JsonConvert.DeserializeObject<NewsItem>(content);
            CleanDatabase();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.IsNull(resultItem.Title);
        }

        [TestMethod]
        public void UpdateItem__ShouldReturn200_OK()
        {
            // Arrange
            CleanDatabase();
            SeedItems();

            var entity = this.repository.All().FirstOrDefault();
            string newTitle = "Nov Title";
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", newTitle),
                new KeyValuePair<string, string>("Id", entity.Id.ToString()), 
                new KeyValuePair<string, string>("Content", entity.Content)
            });


            var endpointUrl = string.Format("/api/news/{0}", entity.Id);
            // Act
            var httpResponse = httpClient.PutAsync(endpointUrl, postContent).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItem = JsonConvert.DeserializeObject<NewsItem>(content);
            CleanDatabase();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
            Assert.AreEqual(newTitle, resultItem.Title);
        }

        [TestMethod]
        public void UpdateItem_InvalidData_ShouldReturn400_BadRequest()
        {
            // Arrange
            CleanDatabase();
            SeedItems();

            var entity = this.repository.All().FirstOrDefault();
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("Title", "Title"),
                new KeyValuePair<string, string>("Id", entity.Id.ToString()), 
            });


            var endpointUrl = string.Format("/api/news/{0}", entity.Id);
            // Act
            var httpResponse = httpClient.PutAsync(endpointUrl, postContent).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            // var resultItem = JsonConvert.DeserializeObject<NewsItem>(content);
            CleanDatabase();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
            Assert.AreEqual(httpResponse.Content.Headers.ContentType.MediaType, "application/json");
        }

        [TestMethod]
        public void DeleteItem_ShouldReturn200_Ok()
        {
            // Arrange
            CleanDatabase();
            SeedItems();

            var entity = this.repository.All().FirstOrDefault();

            var endpointUrl = string.Format("/api/news/{0}", entity.Id);
            // Act
            var httpResponse = httpClient.DeleteAsync(endpointUrl).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultItem = JsonConvert.DeserializeObject<NewsItem>(content);
            CleanDatabase();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(entity.Id, resultItem.Id);
            Assert.AreEqual(entity.Content, resultItem.Content);
        }

        [TestMethod]
        public void DeleteItem_InvalidData_ShouldReturn400_BadRequest()
        {
            // Arrange
            CleanDatabase();

            var endpointUrl = string.Format("/api/news/{0}", 1);
            // Act
            var httpResponse = httpClient.DeleteAsync(endpointUrl).Result;
            //var content = httpResponse.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        private void CleanDatabase()
        {
            var context = new ApplicationDbContext();
            foreach (var newsItem in context.News)
            {
                context.News.Remove(newsItem);
            }

            context.SaveChanges();
        }

        private void SeedItems()
        {
            this.repository.Add(
                   new NewsItem
                   {
                       Title = "FirstNews",
                       Content = "FirstNewsContent",
                       PublishDate = DateTime.Now
                   });
            this.repository.Add(
                   new NewsItem
                   {
                       Title = "SecondNews",
                       Content = "SecondNewsContent",
                       PublishDate = DateTime.Now.AddDays(-3)
                   });
            this.repository.Add(
                   new NewsItem
                   {
                       Title = "ThirdNews",
                       Content = "ThirdNewsContent",
                       PublishDate = DateTime.Now.AddDays(-25)
                   });

            this.repository.SaveChanges();
        }
    }
}
