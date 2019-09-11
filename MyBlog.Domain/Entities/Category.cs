using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }


        public ICollection<Post> Posts { get; set; }
    }
}
