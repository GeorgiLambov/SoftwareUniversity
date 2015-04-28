namespace BugTracker.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;

    using BugTracker.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BugsTests
    {
        [TestMethod]
        public void CreateBugs_ListBugs_ShouldListCreatedBugsCorrectly()
        {
            // Arrange -> prepare a few bugs
            TestingEngine.CleanDatabase();
            var bugsToAdds = new BugModel[]
            {
                new BugModel() { Title = "First Bug" },
                new BugModel() { Title = "Second Bug", Description = "More info"},
                new BugModel() { Title = "Third Bug" }
            };

            // Act -> submit a few bugs
            foreach (var bug in bugsToAdds)
            {
                var httpPostResponse = TestingEngine.SubmitBugHttpPost(bug.Title, bug.Description);
                Thread.Sleep(2);

                // Assert -> ensure each bug is successfully submitted
                Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            }

            // Assert -> list the bugs and assert their count, order and content are correct
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs").Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var bugsFromService = httpResponse.Content.ReadAsAsync<List<BugModel>>().Result;
            Assert.AreEqual(bugsToAdds.Count(), bugsFromService.Count);

            var reversedAddedBugs = bugsToAdds.Reverse().ToList();
            for (int i = 0; i < reversedAddedBugs.Count; i++)
            {
                Assert.IsTrue(bugsFromService[i].Id != 0);
                Assert.AreEqual(reversedAddedBugs[i].Title, bugsFromService[i].Title);
            }
        }

        [TestMethod]
        public void GetBugById_ExistingBug_ShouldReturn200Ok_TheBugWithComments()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";
            
            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment = 
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);
            Thread.Sleep(2);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);

            // Act -> find the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id).Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var bugFromService = httpResponse.Content.ReadAsAsync<BugModel>().Result;
            Assert.IsTrue(bugFromService.Id > 0);
            Assert.AreEqual(bugTitle, bugFromService.Title);
            Assert.AreEqual(bugDescription, bugFromService.Description);
            Assert.AreEqual(null, bugFromService.Author);
            Assert.AreEqual("Open", bugFromService.Status.ToString());
            Assert.IsTrue(bugFromService.DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));
            
            Assert.AreEqual(2, bugFromService.Comments.Count());

            Assert.IsTrue(bugFromService.Comments[0].Id > 0);
            Assert.AreEqual("Comment 2", bugFromService.Comments[0].Text);
            Assert.AreEqual(null, bugFromService.Comments[0].Author);
            Assert.IsTrue(bugFromService.Comments[0].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));

            Assert.IsTrue(bugFromService.Comments[1].Id > 0);
            Assert.AreEqual("Comment 1", bugFromService.Comments[1].Text);
            Assert.AreEqual(null, bugFromService.Comments[1].Author);
            Assert.IsTrue(bugFromService.Comments[1].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));
        }

        [TestMethod]
        public void EditExistingBug_ShouldReturn200OK_Modify()
        {
            // Arrange -> create a new bug
            var httpPostResponse = TestingEngine.SubmitBugHttpPost("bug title", "description");
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            // Act -> edit the above created bug
            var httpPatchResponse = TestingEngine.EditBugHttpPatch(
                submittedBug.Id, "new title", "new description", "Closed");

            // Assert -> 200 OK
            Assert.AreEqual(HttpStatusCode.OK, httpPatchResponse.StatusCode);

            // Assert the service holds the modified bug
            var httpGetResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id).Result;
            var bugFromService = httpGetResponse.Content.ReadAsAsync<BugModel>().Result;
            Assert.AreEqual(HttpStatusCode.OK, httpGetResponse.StatusCode);
            Assert.AreEqual(submittedBug.Id, bugFromService.Id);
            Assert.AreEqual("new title", bugFromService.Title);
            Assert.AreEqual("new description", bugFromService.Description);
            Assert.AreEqual("Closed", bugFromService.Status.ToString());
        }

        [TestMethod]
        public void DeleteBug_WithComments_ShouldReturn200Ok_RemoveTheBug()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";

            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);

            // Act -> delete the bug by its ID
            var httpResponseDeleteBug = TestingEngine.HttpClient.DeleteAsync("/api/bugs/" + submittedBug.Id).Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponseDeleteBug.StatusCode);

            var httpResponseGetBug = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id).Result;
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponseGetBug.StatusCode);
        }

        [TestMethod]
        public void CreateBugs_ListBugsByFilter_ShouldReturnsBugsCorrectly()
        {
            // Arrange -> prepare a few bugs
            TestingEngine.CleanDatabase();

            var httpResponseBug1 = TestingEngine.SubmitBugHttpPost("First Bug", null);
            Assert.AreEqual(HttpStatusCode.Created, httpResponseBug1.StatusCode);
            var submittedBug = httpResponseBug1.Content.ReadAsAsync<BugModel>().Result;
            var httpPatchResponse = TestingEngine.EditBugHttpPatch(
                submittedBug.Id, null, null, "Fixed");
            Assert.AreEqual(HttpStatusCode.OK, httpPatchResponse.StatusCode);
            Thread.Sleep(2);

            var httpResponseBug2 = TestingEngine.SubmitBugHttpPost("Second Bug", "Second Description");
            Assert.AreEqual(HttpStatusCode.Created, httpResponseBug2.StatusCode);
            Thread.Sleep(2);

            var httpResponseBug3 = TestingEngine.SubmitBugHttpPost("Strange Issue", null);
            Assert.AreEqual(HttpStatusCode.Created, httpResponseBug3.StatusCode);
            Thread.Sleep(2);

            // Act -> filter bugs
            var httpResponseFilterBugs = TestingEngine.FilterBugsHttpGet("Bug", "Fixed|Open", null);
            Assert.AreEqual(HttpStatusCode.OK, httpResponseFilterBugs.StatusCode);

            // Assert -> list the bugs and assert their count, order and content are correct
            var bugsFromService = httpResponseFilterBugs.Content.ReadAsAsync<List<BugModel>>().Result;
            Assert.AreEqual(2, bugsFromService.Count());
            Assert.AreEqual("Second Bug", bugsFromService[0].Title);
            Assert.AreEqual("First Bug", bugsFromService[1].Title);
        }
    }
}
