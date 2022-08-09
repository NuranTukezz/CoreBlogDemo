using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogDemo.ViewComponents.Writer
{
    public class WriterAboutOnDahsboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());


        Context c = new Context();


        public  IViewComponentResult Invoke()
        {
           

            var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir

            ViewBag.v = userName;

            var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();

            var writerId = c.Writers.Where(x=>x.WriterMail==userMail).Select(y=>y.WriterID).FirstOrDefault();

            var values = writerManager.GetWriterById(writerId);
            return View(values);//sisteme otantike olan kullanıcıya ait değerler gelecek


        }
    }

}
