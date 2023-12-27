using System.ComponentModel.DataAnnotations;

namespace Project.CoreBlog.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad soyad giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage= "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail  Adres")]
        [Required(ErrorMessage = "Lütfen Mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı giriniz")]
        public string UserName { get; set; }




    }
}
