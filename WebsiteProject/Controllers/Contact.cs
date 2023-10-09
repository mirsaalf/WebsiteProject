using Microsoft.AspNetCore.Mvc;

namespace WebsiteProject.Controllers
{
    public class Contact : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
