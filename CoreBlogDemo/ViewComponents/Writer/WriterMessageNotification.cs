using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlogDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm =new Message2Manager(new EfMessage2Repository());
        Context c=new Context();

        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();


            

             var values = mm.GetInboxListByWriter(writerId);

            return View(values);
        }
    }
}
