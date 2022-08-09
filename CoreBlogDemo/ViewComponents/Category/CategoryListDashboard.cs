using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlogDemo.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();

            return View(values);
        }

    }
}
