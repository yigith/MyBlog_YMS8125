using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.UI.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-mail adresi.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Parola")]
        [MinLength(6, ErrorMessage = "Parola en az 6 karakterden oluşmalı.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        [Display(Name = "Parola (Tekrar)")]
        public string ConfirmPassword { get; set; }
    }
}
