using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogDemo.Controllers
{
   // [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        //mail bültenine abone olmak için oluşturuldu

        NewsLetterManager nm = new NewsLetterManager(new EFNewsLetterRepository());


        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            nm.AddNewsLetter(newsLetter);
            return RedirectToAction("Index", "Blog");
        }
    }
}
