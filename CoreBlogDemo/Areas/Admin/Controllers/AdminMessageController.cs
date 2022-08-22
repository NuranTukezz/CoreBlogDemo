using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult Inbox()//Gelen Mesaj
        {
            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = mm.GetInboxListByWriter(writerId);

            return View(values);

        }

        public IActionResult SendBox()//Giden Mesaj
        {
            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = mm.GetSendBoxListByWriter(writerId);

            return View(values);
        }
        [HttpGet]
        public IActionResult Composemessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Composemessage(Message2 p)
        {
            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            p.SenderID = writerId;
            p.ReceiverID = 4;
            p.MessageStatus = true;
            p.MessageDate = System.DateTime.Now;//DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.TAdd(p);

            return RedirectToAction("SendBox");
        }


    }
}
