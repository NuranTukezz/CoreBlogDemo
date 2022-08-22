using System.ComponentModel.DataAnnotations;

namespace CoreBlogDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütfen rol adı giriniz")]
        public string Name { get; set; }


    }
}
