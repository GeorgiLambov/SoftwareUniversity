namespace BlogSystem.WebServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Microsoft.AspNet.Identity;

    public abstract class BaseApiController : ApiController
    {
        private IBlogSystemData data;

        protected BaseApiController()
        {
            this.data = new BlogSystemData(new BlogSystemDbContext());
        }

        protected IBlogSystemData Data
        {
            get { return this.data; }
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }
    }
}