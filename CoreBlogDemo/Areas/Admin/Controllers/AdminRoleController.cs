﻿using CoreBlogDemo.Areas.Admin.Models;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();

            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }
        [HttpPost]
        public async Task< IActionResult > AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };

                var result=await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=>x.Id==id);

            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task< IActionResult> UpdateRole(RoleUpdateViewModel model)
        {
            var values=_roleManager.Roles.Where(x=>x.Id==model.Id).FirstOrDefault();
            values.Name=model.Name;
            var result=await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values =_roleManager.Roles.FirstOrDefault(x=>x.Id == id);
            var result=await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task< IActionResult> AssignRole(int id)
        {
            var user=_userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles=_roleManager.Roles.ToList();//=>BÜTÜN ROLLER LİSTELENECEK

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);//=>KULLANICIYA AİT ROL ÇEKİLİYOR

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();

            foreach (var item in roles) //=>BÜTÜN ROLLERİ DOLAŞ
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleId = item.Id;
                m.Name=item.Name;
                m.NormalizedName=item.NormalizedName;

                m.Exist = userRoles.Contains(item.Name); //TRUE OLANLARI ÇEK
                model.Add(m); 
            }
             

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId =(int)TempData["UserId"];
            var user=_userManager.Users.First(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user,item.Name);//CHECKBOX'TA SEÇİLİ OLAN DEĞERLERİ ROLE TABLOSUNA EKLEYECEK
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
