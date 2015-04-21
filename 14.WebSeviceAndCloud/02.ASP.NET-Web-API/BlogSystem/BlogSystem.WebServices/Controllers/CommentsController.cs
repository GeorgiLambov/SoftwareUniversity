namespace BlogSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Data.Repositories;
    using BlogSystem.Models;
    using WebServices.Controllers;

    public class CommentsController : BaseApiController
    {
        private IRepository<Comment> repository;

        public CommentsController()
        {
            this.repository = this.Data.Comments;
        }

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return repository.All();
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = repository.Find(c => c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            repository.Update(comment);
            repository.SaveChanges();

            return this.Ok(comment);
        }

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Add(comment);
            repository.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = repository.Find(c => c.Id == id).FirstOrDefault();
            if (comment == null)
            {
                return NotFound();
            }

            repository.Delete(comment);
            repository.SaveChanges();

            return Ok(comment);
        }
    }
}