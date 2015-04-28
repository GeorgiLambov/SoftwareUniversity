namespace StudentSystem.Web.Controllers
{
    using System.Web.Mvc;
    using Data;

    public class HomeController : Controller
    {
        private IStudentSystemData data;

        public HomeController()
        {
            this.data = new StudentsSystemData();
        }

        public ActionResult Index()
        {
            var students = this.data.Students.All();

            return View(students);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}