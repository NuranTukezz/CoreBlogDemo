using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreBlogDemo.Areas.Admin.ViewComponents.Statistic
{

    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();


            //d18649256b5f539381db4f31bdf344e9
            string api = "d18649256b5f539381db4f31bdf344e9";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+api;

            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document
                .Descendants("temperature")
                .Attributes("value").
                ElementAt(0).Value;

            return View();
        }
    }
}
