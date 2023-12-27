using System.ComponentModel.DataAnnotations;

namespace Project.CoreBlog.Models
{
    public class RoleViewModel
    {

        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Lütfen rol adınızı giriniz")]
        public string name { get; set; }
    }
}
