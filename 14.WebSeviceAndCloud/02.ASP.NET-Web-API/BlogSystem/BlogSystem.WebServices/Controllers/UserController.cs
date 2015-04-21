namespace BlogSystem.WebServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;

    [Authorize]
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
 
        //public UserController()
        //    : base(new IBlogSystemData())
        //{
        //    this.userManager = new ApplicationUserManager(
        //        new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //}
    }
}