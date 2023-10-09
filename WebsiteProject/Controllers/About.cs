using Microsoft.AspNetCore.Mvc;

namespace WebsiteProject.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
