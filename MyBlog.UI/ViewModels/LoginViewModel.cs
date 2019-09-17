using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.UI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-mail adresi.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
