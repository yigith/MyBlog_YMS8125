using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBlog.Domain.Enums
{
    public enum UserType
    {
        [Display(Name = "Administrator")]
        Admin = 1,
        [Display(Name = "Guest")]
        Guest = 2
    }
}
