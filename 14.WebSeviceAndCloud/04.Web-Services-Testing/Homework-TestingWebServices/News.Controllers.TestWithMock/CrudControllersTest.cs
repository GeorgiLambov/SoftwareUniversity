namespace News.Controllers.TestWithMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Data;
    using Data.Repositories;
    using Data.UnitOfWorkData;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;
    using Newtonsoft.Json;
    using WebServices.Controllers;

    [TestClass]
    public class CrudControllersTest
    {
        private static List<NewsItem> GetNewsItemsNews()
        {
            var news = new List<NewsItem>
            {
                new NewsItem
                {
                    Id = 1,
                    Title = "FirstNews",
                    Content = "FirstNewsContent",
                    PublishDate = DateTime.Now
                },
                new NewsItem
                {
                    Id = 2,
                    Title = "SecondNews",
                    Content = "SecondNewsContent",
                    PublishDate = DateTime.Now.AddDays(-3)
                },
                new NewsItem
                {
                    Id = 3,
                    Title = "ThirdNews",
                    Content = "ThirdNewsContent",
                    PublishDate = DateTime.Now.AddDays(-25)
                }
            };
            return news;
        }

        private void SetupController(ApiController controller, string controllerName)
        {
            string serverUrl = "http://sample-url.com";

            // Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            // Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            // Apply the routes to the controller
            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary
                {
                    { "controller", controllerName }
                });
        }

        private IUnitOfWork data;
        private IRepository<NewsItem> repository;

        public CrudControllersTest()
        {
            this.data = new DbUnitOfWork(new ApplicationDbContext());
            this.repository = this.data.NewsRepository;
        }

        [TestInitialize]
        public void TestInit()
        {
        }

        [TestMethod]
        public void GetAll_WithValidData_ShouldSucceed()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            // Act
            var httpResponse = controller.GetNewsItems().ExecuteAsync(new CancellationToken()).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultNews = JsonConvert.DeserializeObject<List<NewsItem>>(content);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            CollectionAssert.AreEqual(news, resultNews.ToArray<NewsItem>());
            Assert.AreEqual(3, news.Count);
        }

        [TestMethod]
        public void PostNewsItem_WithValidData_ShouldSucceed()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");


            var newNewsItem = new NewsItem()
            {
                Title = "ThirdNews",
                Content = "ThirdNewsContent",
                PublishDate = DateTime.Now.AddDays(8)
            };

            // Act
            var httpResponse = controller.PostNewsItem(newNewsItem).ExecuteAsync(new CancellationToken()).Result;
            var content = httpResponse.Content.ReadAsStringAsync().Result;
            var resultNews = JsonConvert.DeserializeObject<NewsItem>(content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, httpResponse.StatusCode);
            Assert.IsNotNull(httpResponse.Headers.Location);

            Assert.IsNotNull(resultNews.PublishDate);
            Assert.AreEqual(newNewsItem.Title, resultNews.Title);
            Assert.AreEqual(newNewsItem.Content, resultNews.Content);
        }

        [TestMethod]
        public void PostNewsItem_WithInvalidData_ShouldReturnBadRequest()
        {
            var repo = new RepositoryMock();
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            var newNewsItem = new NewsItem()
            {
                Title = "Bad Item",
                PublishDate = DateTime.Now.AddDays(8)
            };

            // Act
            var httpResponseMessage = controller.PostNewsItem(newNewsItem).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);
        }

        [TestMethod]
        public void GetNewsItemByID_ShouldReturnBadRequest()
        {
            var repo = new RepositoryMock();
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            // Act
            var resultPostAction = controller.GetNewsItem(1).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, resultPostAction.StatusCode);
        }

        [TestMethod]
        public void ModifyNewsItem_WithValidData_ShouldSucceed()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");


            var newNewsItem = new NewsItem()
            {
                Id = 2,
                Title = "fourt",
                Content = "fourt",
                PublishDate = DateTime.Now
            };

            // Act
            var resultPostAction = controller.PutNewsItem(2, newNewsItem).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, resultPostAction.StatusCode);

            // Update retern only HttpStatusCode.OK
            //var content = resultPostAction.Content.ReadAsStringAsync().Result;
            //var resultNews = JsonConvert.DeserializeObject<NewsItem>(content);


            //Assert.IsNotNull(resultNews.PublishDate);
            //Assert.AreEqual(newNewsItem.Title, resultNews.Title);
            //Assert.AreEqual(newNewsItem.Content, resultNews.Content);
        }

        [TestMethod]
        public void ModifyNonExistingNewsItem_ShouldReturnBadRequest()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");


            var newNewsItem = new NewsItem()
            {
                Id = 4,
                Title = "fourt",
                Content = "fourt",
                PublishDate = DateTime.Now
            };

            // Act
            var resultPostAction = controller.PutNewsItem(4, newNewsItem).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, resultPostAction.StatusCode);
        }

        [TestMethod]
        public void DeleteNewsItemByID_WithValidData_ShouldSucceed()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            // Act
            var resultPostAction = controller.DeleteNewsItem(news[2].Id).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, resultPostAction.StatusCode);

            var content = resultPostAction.Content.ReadAsStringAsync().Result;
            var resultNews = JsonConvert.DeserializeObject<NewsItem>(content);
        }

        [TestMethod]
        public void DeleteNonExistingNewsItemByID_ShouldReturnBadRequest()
        {
            var repo = new RepositoryMock();
            var news = GetNewsItemsNews();

            repo.Entities = news;
            var controller = new NewsController(repo);
            SetupController(controller, "news");

            // Act
            var resultPostAction = controller.DeleteNewsItem(5).ExecuteAsync(new CancellationToken()).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, resultPostAction.StatusCode);
        }
    }
}

