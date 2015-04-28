namespace News.WebServices.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Data.Repositories;
    using Data.UnitOfWorkData;
    using News.Models;

    public class NewsController : BaseApiController
    {
        public NewsController()
            : this(new DbUnitOfWork())
        {
        }

        public NewsController(IUnitOfWork data)
            : base(data)
        {
        }

        // GET: api/News
        [HttpGet]
        public IHttpActionResult GetNewsItems()
        {
            return Ok(this.Data.NewsRepository.All().AsQueryable());
        }

        // GET: api/News/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult GetNewsItem(int id)
        {
            NewsItem newsItem = this.Data.NewsRepository.GetById(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            return Ok(newsItem);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsItem(int id, NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = this.Data.NewsRepository.GetById(id);
            if (id != newsItem.Id || item == null)
            {
                return BadRequest();
            }

            this.Data.NewsRepository.Update(newsItem);
            this.Data.NewsRepository.SaveChanges();
            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/News
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult PostNewsItem(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.Data.NewsRepository.Add(newsItem);
            this.Data.NewsRepository.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsItem.Id }, newsItem);
        }

        // DELETE: api/News/5
        [ResponseType(typeof(NewsItem))]
        public IHttpActionResult DeleteNewsItem(int id)
        {
            NewsItem newsItem = this.Data.NewsRepository.GetById(id);
            if (newsItem == null)
            {
                return NotFound();
            }

            this.Data.NewsRepository.Delete(newsItem);
            this.Data.NewsRepository.SaveChanges();

            return Ok(newsItem);
        }
    }
}