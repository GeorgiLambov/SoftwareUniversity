namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using Data.Models;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models;

    [RoutePrefix("api")]
    public class CommentsController : ApiController
    {
        private readonly IBugsData db;

        public CommentsController()
            : this(new BugsData())
        {
        }

        public CommentsController(IBugsData data)
        {
            this.db = data;
        }

        //GET /api/comments
        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            var comments = db.Comments.All()
                .OrderByDescending(c => c.PublishDate)
                .ThenBy(b => b.Id);

            return this.Ok(
                comments.Select(c =>
                    new
            {
                Id = c.Id,
                Text = c.Text,
                DateCreated = c.PublishDate,
                Author = (c.Author != null) ? c.Author.UserName : null,
                BugId = c.BugId,
                BugTitle = c.Bug.Title
            }));
        }

        //GET /api/bugs/{id}/comments
        [HttpGet]
        [Route("bugs/{id}/comments")]
        public IHttpActionResult GetBugComments(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = db.Comments.All()
                .Where(c => c.BugId == id)
                .OrderByDescending(c => c.PublishDate)
                .ThenBy(b => b.Id);

            return this.Ok(comments.Select(c =>
                new
                {
                    Id = c.Id,
                    Text = c.Text,
                    DateCreated = c.PublishDate,
                    Author = (c.Author != null) ? c.Author.UserName : null,
                }));
        }

        //POST /api/bugs/{id}/comments
        [HttpPost]
        [Route("bugs/{id:int}/comments")]
        public IHttpActionResult CreateCommentsByBugId(int id, [FromBody] CommentInputModel commentInputData)
        {
            if (commentInputData == null)
            {
                return BadRequest("Missing comment data.");
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.db.Users.Find(currentUserId);
            var comment = new Comment()
            {
                BugId = bug.Id,
                Text = commentInputData.Text,
                Author = currentUser,
                PublishDate = DateTime.Now,
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            if (bug.Author == null)
            {
                return this.Ok(
                    new { bug.Id, Message = "Added anonymous comment for bug #" + bug.Id + '"' });
            }

            return this.Ok(
                new
                {
                    bug.Id,
                    Author = bug.Author.UserName,
                    Message = "Added anonymous comment for bug #" + bug.Id + '"'
                });
        }
    }
}