namespace BlogSystem.WebServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    using Data.Repositories;

    [Authorize]
    public class PostsController : BaseApiController
    {
        private IRepository<Post> repository;

        public PostsController()
        {
            this.repository = this.Data.Posts;
        }

        // GET: api/Post
        [HttpGet]
        public IHttpActionResult GetAllPost()
        {
            return this.Ok(this.repository.All()
                .Select(p => new
                    {
                        p.Id,
                        p.Content
                    }));
        }

        // GET: api/Posts/3
        public IHttpActionResult GetPost(int id)
        {
            var post = this.repository.Find(p => p.Id == id)
                .Select(p => new
                    {
                        p.Id,
                        p.Content
                    }).FirstOrDefault();
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // Update: api/Posts/3
        [HttpPut]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            repository.Update(post);
            repository.SaveChanges();

            return this.Ok(post);
        }

        // Add: api/Posts
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Add(post);
            repository.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/3
        public IHttpActionResult DeletePost(int id)
        {
            Post post = repository.Find(p => p.Id == id).FirstOrDefault();
            if (post == null)
            {
                return NotFound();
            }

            repository.Delete(post);
            repository.SaveChanges();

            return Ok(post);
        }
    }
}