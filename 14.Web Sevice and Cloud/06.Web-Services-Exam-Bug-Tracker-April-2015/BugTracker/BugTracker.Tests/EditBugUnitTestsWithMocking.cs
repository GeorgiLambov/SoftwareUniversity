namespace BugTracker.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    
    using BugTracker.Data.Models;
    using BugTracker.RestServices.Controllers;
    using BugTracker.RestServices.Models;
    using BugTracker.Tests.Mocks;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RouteParameter = System.Web.Http.RouteParameter;

    [TestClass]
    public class EditBugUnitTestsWithMocking
    {
        [TestMethod]
        public void EditBug_ExistingBug_ShouldReturn200OK_CorrectBugData()
        {
            // Arrange -> create a few bugs
            var dataLayerMock = new BugTrackerDataMock();
            var bugsMock = dataLayerMock.Bugs;
            bugsMock.Add(new Bug() { Id = 1, Title = "Bug #1" });
            bugsMock.Add(new Bug()
            {
                Id = 2, 
                Title = "Bug #2 for edit ...", 
                Description = "Description for edit ...", 
                Status = BugStatus.Fixed
            });
            bugsMock.Add(new Bug() { Id = 3, Title = "Bug #3" });
            var newTitle = "new title";
            var newDescription = "new description";
            var newStatus = BugStatus.Closed;

            // Act -> edit bug data
            var bugsController = new BugsController(dataLayerMock);
            this.SetupControllerForTesting(bugsController, "bugs");
            var editBugData = new EditBugBindingModel()
            {
                Title = newTitle,
                Description = newDescription,
                Status = newStatus
            };
            var httpResponse = bugsController.EditBug(2, editBugData)
                .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> HTTP status code 200 (OK) + bug data changed
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            Assert.AreEqual(2, bugsMock.Find(2).Id);
            Assert.AreEqual(newTitle, bugsMock.Find(2).Title);
            Assert.AreEqual(newDescription, bugsMock.Find(2).Description);
            Assert.AreEqual(newStatus, bugsMock.Find(2).Status);
        }

        [TestMethod]
        public void EditBug_NonExistingBug_ShouldReturn404NotFound()
        {
            // Arrange -> create a few bugs
            var dataLayerMock = new BugTrackerDataMock();
            var bugsMock = dataLayerMock.Bugs;
            bugsMock.Add(new Bug() { Id = 1, Title = "Bug #1" });
            bugsMock.Add(new Bug() { Id = 2, Title = "Bug #2" });

            // Act -> edit bug data
            var bugsController = new BugsController(dataLayerMock);
            this.SetupControllerForTesting(bugsController, "bugs");
            var editBugData = new EditBugBindingModel() { Title = "new title" };
            var httpResponse = bugsController.EditBug(1234, editBugData)
                .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> HTTP status code 404 (Not Found)
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditBug_InvalidBugData_ShouldReturn400BadRequest()
        {
            // Arrange -> create a few bugs
            var dataLayerMock = new BugTrackerDataMock();
            var bugsMock = dataLayerMock.Bugs;
            bugsMock.Add(new Bug() { Id = 1, Title = "Bug #1" });
            bugsMock.Add(new Bug() { Id = 2, Title = "Bug #2" });

            // Act -> edit bug data
            var bugsController = new BugsController(dataLayerMock);
            this.SetupControllerForTesting(bugsController, "bugs");
            EditBugBindingModel editBugData = null;
            var httpResponse = bugsController.EditBug(1, editBugData)
                .ExecuteAsync(new CancellationToken()).Result;

            // Assert -> HTTP status code 400 (BadRequest)
            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
        
        private void SetupControllerForTesting(ApiController controller, string controllerName)
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
    }
}
