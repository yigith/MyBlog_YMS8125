using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
