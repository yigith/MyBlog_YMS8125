using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BLL.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class PostsController : AdminBaseController
    {
        IUserService _userService;
        ICategoryService _categoryService;
        IPostService _postService;
        public PostsController(IUserService userService, ICategoryService categoryService, IPostService postService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            ViewBag.CategoryItems = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult New(Post model)
        {
            return View();
        }
    }
}