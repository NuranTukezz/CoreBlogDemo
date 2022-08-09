using Microsoft.AspNetCore.Mvc;

namespace CoreBlogDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
