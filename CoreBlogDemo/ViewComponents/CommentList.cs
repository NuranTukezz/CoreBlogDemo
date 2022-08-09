using CoreBlogDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreBlogDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            var commentValues = new List<UserComment>
            {
                new UserComment
                { ID = 1, UserName="Nuran"},
                new UserComment
                { ID = 2, UserName="Turgay"},
                new UserComment
                { ID = 3, UserName="Zeynep Sude"},
                 new UserComment
                { ID = 4, UserName="Mustafa"}

            };

            return View(commentValues);

        }
    }
}
