namespace BugTracker.RestServices.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Redirect to Web API Help Page (Documentation)
            return this.Redirect("Help");
        }
    }
}
