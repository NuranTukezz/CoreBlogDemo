using DataAccessLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            Context c = new Context();

            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            ViewBag.InboxCount = c.Message2s.Where(x => x.ReceiverID == writerID).Select(y => y.MessageStatus == false).Count();

            return PartialView();
        }
    }
}
