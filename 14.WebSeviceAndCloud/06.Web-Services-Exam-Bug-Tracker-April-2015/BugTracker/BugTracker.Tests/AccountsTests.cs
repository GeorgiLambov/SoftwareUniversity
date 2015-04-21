namespace BugTracker.Tests
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;

    using BugTracker.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountsTests
    {
        [TestMethod]
        public void RegisterUser_EmptyDb_ShouldReturn200Ok_AccessToken()
        {
            // Arrange
            TestingEngine.CleanDatabase();
            var username = "peter";

            // Act
            var postContent = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", "pAssW@rd#123456")
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;

            // Assert
            Assert.AreEqual(userSession.UserName, username);
            Assert.IsNotNull(userSession.Access_Token);
        }

        [TestMethod]
        public void RegisterUser_InvalidUserData_ShouldReturn400_BadRequest()
        {
            // Arrange
            TestingEngine.CleanDatabase();

            // Act -> empty username
            var responseEmptyUsername = TestingEngine.RegisterUserHttpPost("", "#paSSw@rd12345");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseEmptyUsername.StatusCode);

            // Act -> empty password
            var responseEmptyPassword = TestingEngine.RegisterUserHttpPost("maria", "");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseEmptyPassword.StatusCode);

            // Act -> null username
            var responseNullUsername = TestingEngine.RegisterUserHttpPost(null, "#paSSw@rd12345");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseNullUsername.StatusCode);

            // Act -> null password
            var responseNullPassword = TestingEngine.RegisterUserHttpPost("maria", null);
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseNullPassword.StatusCode);

            // Act -> no data (empty HTTP body)
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", null).Result;
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_DuplicatedUsername_ShouldReturn400_BadRequest()
        {
            // Arrange
            TestingEngine.CleanDatabase();

            // Act
            var responseFirstRegistration = TestingEngine.RegisterUserHttpPost("maria", "#paSSw@rd12345");
            var responseSecondRegistration = TestingEngine.RegisterUserHttpPost("maria", "0th3RPassw@rd");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, responseFirstRegistration.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseSecondRegistration.StatusCode);
        }

        [TestMethod]
        public void UserLogin_ValidUser_ShouldReturn200Ok_AccessToken()
        {
            // Arrange
            TestingEngine.CleanDatabase();
            var username = "peter";
            var password = "#paSSw@rd12345";

            // Act
            var userSessionRegister = TestingEngine.RegisterUser(username, password);
            var userSessionLogin = TestingEngine.LoginUser(username, password);

            // Assert
            Assert.AreEqual(username, userSessionRegister.UserName);
            Assert.AreEqual(username, userSessionLogin.UserName);
            Assert.AreEqual(userSessionLogin.UserName, userSessionRegister.UserName);
            Assert.AreNotEqual(userSessionLogin.Access_Token, userSessionRegister.Access_Token);
        }

        [TestMethod]
        public void UserLogin_InvalidUser_ShouldReturn400_BadRequest()
        {
            // Arrange
            TestingEngine.CleanDatabase();
            var username = "peter";
            var password = "#paSSw@rd12345";

            // Act
            var loginResponse = TestingEngine.LoginUserHttpPost(username, password);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, loginResponse.StatusCode);
        }

        [TestMethod]
        public void UserLogin_InvalidLoginData_ShouldReturn400_BadRequest()
        {
            // Arrange
            TestingEngine.CleanDatabase();

            // Act -> empty username
            var responseEmptyUsername = TestingEngine.LoginUserHttpPost("", "#paSSw@rd12345");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseEmptyUsername.StatusCode);

            // Act -> empty password
            var responseEmptyPassword = TestingEngine.LoginUserHttpPost("maria", "");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseEmptyPassword.StatusCode);

            // Act -> null username
            var responseNullUsername = TestingEngine.LoginUserHttpPost(null, "#paSSw@rd12345");
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseNullUsername.StatusCode);

            // Act -> null password
            var responseNullPassword = TestingEngine.LoginUserHttpPost("maria", null);
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, responseNullPassword.StatusCode);

            // Act -> no data (empty HTTP body)
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", null).Result;
            // Assert -> 400 (Bad Request)
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
    }
}
