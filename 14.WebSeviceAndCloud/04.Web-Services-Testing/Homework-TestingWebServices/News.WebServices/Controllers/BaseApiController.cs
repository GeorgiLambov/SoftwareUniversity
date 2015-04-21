namespace News.WebServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.Repositories;
    using Data.UnitOfWorkData;
    using News.Models;

    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IUnitOfWork data)
        {
            this.Data = data;
        }

        protected IUnitOfWork Data
        {
            get;
            private set;
        }
    }
}