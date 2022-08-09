using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;




namespace CoreBlogDemo.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    //[HttpPost]
    //public IActionResult AddComment(Comment c)
    //{
    //   // comments.Add(c);
    //    var jsonWriters = JsonConvert.SerializeObject(c);
    //    return Json(jsonWriters);
    //}

    //public static List<Comment> comments()
    //{

    //}

}
