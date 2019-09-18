using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.UI.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Category> Categories { get; set; }

        public List<Post> Posts { get; set; }
    }
}
