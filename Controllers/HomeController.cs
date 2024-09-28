using Microsoft.AspNetCore.Mvc;

namespace ASPBookProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return Content("Hello World from Index action, HomeController");
        }

    }
}
