using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlogDemo.Controllers
{

    public class MessageController : Controller
    {

        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult InBox()
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


        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);

             return View(value);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID= writerId;
            p.ReceiverID = 8;
            p.MessageStatus = true;
            p.MessageDate = System.DateTime.Now;//DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.TAdd(p);

            return RedirectToAction("InBox");
        }
        public IActionResult DeleteMessage(int id)
        {

            var value = mm.TGetById(id);
            if (value.IsDelete)
            {
                value.IsDelete = false;
            }
            else
            {
                value.IsDelete = true;
            }
            mm.TUpdate(value);
            return RedirectToAction("Inbox");
        }
    }
}
