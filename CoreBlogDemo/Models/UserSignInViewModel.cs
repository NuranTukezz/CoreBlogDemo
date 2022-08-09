using System.ComponentModel.DataAnnotations;

namespace CoreBlogDemo.Models
{
    public class UserSignInViewModel
    { 
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        public string password { get; set; }
    }
}
