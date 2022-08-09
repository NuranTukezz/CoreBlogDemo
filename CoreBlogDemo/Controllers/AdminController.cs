using Microsoft.AspNetCore.Mvc;

namespace CoreBlogDemo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult AdminNavbarPartial()//sol taraftaki menüler burada tutulacak
        {
            return PartialView();
        }
    }
}
