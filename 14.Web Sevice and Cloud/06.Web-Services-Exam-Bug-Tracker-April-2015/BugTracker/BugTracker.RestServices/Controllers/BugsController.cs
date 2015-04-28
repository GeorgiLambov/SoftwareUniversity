namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Data.Models;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Models;

    public class BugsController : ApiController
    {
        private readonly IBugsData db;

        public BugsController()
            : this(new BugsData())
        {
        }

        public BugsController(IBugsData data)
        {
            this.db = data;
        }

        // GET: api/bugs
        [HttpGet]
        public IHttpActionResult GetBugs()
        {
            var bugs = db.Bugs.All()
                .OrderByDescending(b => b.SubmitDate)
                .ThenBy(b => b.Id);

            return this.Ok(
                bugs.Select(b => new BugBindingModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status,
                    DateCreated = b.SubmitDate,
                    Author = (b.Author != null) ? b.Author.UserName : null
                }));
        }

        // GET: api/bugs/{id}
        [HttpGet]
        public IHttpActionResult GetBugById(int id)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            return this.Ok(
                new BugDetailsModel
                {
                    Id = bug.Id,
                    Title = bug.Title,
                    Status = bug.Status,
                    Description = bug.Description,
                    DateCreated = bug.SubmitDate,
                    Author = (bug.Author != null) ? bug.Author.UserName : null,
                    Comments = bug.Comments.OrderByDescending(c => c.PublishDate)
                        .Select(c =>
                            new CommentBindingModel
                            {
                                Id = c.Id,
                                Author = c.Author,
                                DateCreated = c.PublishDate,
                                Text = c.Text
                            }).ToList()
                });
        }

        // POST: api/bugs
        [HttpPost]
        public IHttpActionResult CreateBug([FromBody] NewBugBindingModel bugsData)
        {
            if (bugsData == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = this.db.Users.Find(currentUserId);
            var bug = new Bug
            {
                Title = bugsData.Title,
                Author = currentUser,
                SubmitDate = DateTime.Now,
                Description = bugsData.Description,
                Status = BugStatus.Open
            };
            db.Bugs.Add(bug);
            db.SaveChanges();

            if (bug.Author == null)
            {
                return this.CreatedAtRoute(
                    "DefaultApi",
                    new { controller = "bugs", id = bug.Id },
                    new { bug.Id, Message = "Anonymous bug submitted." }
                    );
            }

            return this.CreatedAtRoute(
                "DefaultApi",
                new { controller = "bugs", id = bug.Id },
                new { bug.Id, Author = bug.Author.UserName, Message = "User bug submitted." }
                );
        }

        // PUT: api/bugs/{id}
        [HttpPatch]
        public IHttpActionResult EditBug(int id, [FromBody] EditBugBindingModel bugsData)
        {
            if (bugsData == null)
            {
                return BadRequest();
            }

            var existingBug = db.Bugs.Find(id);
            if (existingBug == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bugsData.Title != null)
            {
                existingBug.Title = bugsData.Title;
            }

            if (bugsData.Description != null)
            {
                existingBug.Description = bugsData.Description;
            }
            if (bugsData.Status != null)
            {
                existingBug.Status = (BugStatus)bugsData.Status;
            }

            db.Bugs.Update(existingBug);
            db.SaveChanges();

            return this.Ok(
                new
                {
                    Message = "Bug #" + id + " patched."
                }
                );
        }

        // DELETE: api/bugs/{id}
        [HttpDelete]
        public IHttpActionResult DeleteBug(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            if (bug.Comments.Any())
            {
                var comments = db.Comments.All().Where(c => c.BugId == bug.Id);
                foreach (var comment in comments)
                {
                    db.Comments.Remove(comment.Id);
                }
            }

            db.Bugs.Remove(bug);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Bug #" + id + " deleted."
            });
        }

        // GET: api/bugs/filter
        [HttpGet]
        [Route("api/bugs/filter")]
        public IHttpActionResult GetBugsByFilter(
            [FromUri] string keyword = null,
            [FromUri] string statuses = null,
            [FromUri] string author = null)
        {
            var bugs = (IEnumerable<Bug>)db.Bugs.All()
               .OrderByDescending(b => b.SubmitDate)
               .ThenBy(b => b.Id);

            if (keyword != null)
            {
                bugs = bugs.Where(b => b.Title.Contains(keyword));
            }

            if (statuses != null)
            {
                string[] allowedStatuses = statuses.Split('|');
                bugs = bugs.Where(b => statuses.Contains(b.Status.ToString()));
            }

            if (author != null)
            {
                bugs = bugs.Where(b => b.Author.UserName == author);
            }

            return this.Ok(bugs.Select(b => new BugBindingModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status,
                    DateCreated = b.SubmitDate,
                    Author = (b.Author != null) ? b.Author.UserName : null
                }));
        }
    }
}