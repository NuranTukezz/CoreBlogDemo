﻿using BusinessLayer.Concrate;
using BusinessLayer.Validationrules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;//=>sayfalama yapmak için paket olarak indirildi

namespace CoreBlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page,3);

            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {

            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDalete(value);
            return RedirectToAction("Index");
        }
    }
}
