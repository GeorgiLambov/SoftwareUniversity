namespace BugTracker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;

    using BugTracker.Data;
    using BugTracker.Data.Models;
    using BugTracker.RestServices;
    using BugTracker.Tests.Models;

    using EntityFramework.Extensions;

    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Owin;

    [TestClass]
    public static class TestingEngine
    {
        private static TestServer TestWebServer { get; set; }

        public static HttpClient HttpClient { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Start OWIN testing HTTP server with Web API support
            TestWebServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });
            HttpClient = TestWebServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestWebServer.Dispose();
        }

        public static void CleanDatabase()
        {
            using (var dbContext = new BugTrackerDbContext())
            {
                dbContext.Comments.Delete();
                dbContext.Bugs.Delete();
                dbContext.Users.Delete();
                dbContext.SaveChanges();
            }
        }

        public static HttpResponseMessage RegisterUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage LoginUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("recipientUsername", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", postContent).Result;
            return httpResponse;
        }

        public static UserSessionModel RegisterUser(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static UserSessionModel LoginUser(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static HttpResponseMessage SubmitBugHttpPost(string title, string description)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("title", title),
                new KeyValuePair<string, string>("description", description)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/bugs", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage SubmitCommentHttpPost(int bugId, string commentText)
        {
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("text", commentText),
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync(
                "/api/bugs/" + bugId + "/comments", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage EditBugHttpPatch(
            int bugId, string title, string description, string status)
        {
            var properties = new List<KeyValuePair<string, string>>();
            if (title != null)
            {
                properties.Add(new KeyValuePair<string, string>("title", title));
            }
            if (description != null)
            {
                properties.Add(new KeyValuePair<string, string>("description", description));
            }
            if (status != null)
            {
                properties.Add(new KeyValuePair<string, string>("status", status));
            }

            var request = new HttpRequestMessage(
                new HttpMethod("PATCH"), new Uri("/api/bugs/" + bugId, UriKind.Relative))
            {
                Content = new FormUrlEncodedContent(properties)
            };
            var httpResponse = TestingEngine.HttpClient.SendAsync(request).Result;
            return httpResponse;
        }

        public static HttpResponseMessage FilterBugsHttpGet(string keyword, string statuses, string author)
        {
            var parameters = new List<KeyValuePair<string, string>>(); 
            if (keyword != null)
            {
                parameters.Add(new KeyValuePair<string, string>("keyword", keyword));
            }
            if (statuses != null)
            {
                parameters.Add(new KeyValuePair<string, string>("statuses", statuses));
            }
            if (author != null)
            {
                parameters.Add(new KeyValuePair<string, string>("author", author));
            }
            var queryString = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/filter?" + queryString).Result;
            return httpResponse;
        }
    }
}
