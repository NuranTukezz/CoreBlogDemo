using System.ComponentModel.DataAnnotations;

namespace CoreBlogDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name =" Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad giriniz.")]
        public string NameSurname { get; set; }


        [Display(Name = " Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre giriniz.")]
        public string Password { get; set; }


        [Display(Name = " Şifre Tekrar")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor!")]//=>eşleltirecek
        public string ConfirmPassword { get; set; }



        [Display(Name = " Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail giriniz.")]
        public string Mail { get; set; }


        [Display(Name = " Kullanıcı Adı ")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı giriniz.")]
        public string UserName { get; set; }
    }
}
