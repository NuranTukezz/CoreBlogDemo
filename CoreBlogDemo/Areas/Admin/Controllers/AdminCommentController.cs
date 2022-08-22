using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = cm.GetCommentWithBlog();//yorumları blogla getir

            return View(values);
        }
        //public IActionResult DeleteBlog(int id)
        //{
        //    var blogvalue = bm.TGetById(id);
        //    bm.TDalete(blogvalue);

        //    return RedirectToAction("BlogListByWriter");
        //}
        //[HttpGet]//sayfa yüklenince çalışacak
        //public IActionResult EditBlog(int id)
        //{
        //    List<SelectListItem> categoryvalues = (from x in cm.GetList()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = x.CategoryName,
        //                                               Value = x.CategoryID.ToString()
        //                                           }).ToList();
        //    ViewBag.cv = categoryvalues;


        //    var blogvalue = bm.TGetById(id);
        //    return View(blogvalue);
        //}

        //[HttpPost]
        //public IActionResult EditBlog(Blog p)
        //{
        //    var userName = User.Identity.Name;//aktif kullanıcının name değerini getirir
        //    var userMail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
        //    var writerId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();



        //    p.WriterID = writerId;
        //    p.BlogCreateDate = System.DateTime.Now;//DateTime.Parse(DateTime.Now.ToShortDateString());
        //    p.BlogStatus = true;
        //    bm.TUpdate(p);
        //    return RedirectToAction("BlogListByWriter");

        //}

    }
}
