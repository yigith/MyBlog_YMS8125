using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Domain.Entities;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class PostsController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Post model)
        {
            return View();
        }
    }
}