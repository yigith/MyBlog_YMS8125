using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBlog.BLL.Interfaces;
using MyBlog.BLL.Services;
using MyBlog.DAL.Contexts;
using MyBlog.DAL.UnitOfWork;
using MyBlog.Domain.Entities;
using MyBlog.UI.Models;
using MyBlog.UI.ViewModels;

namespace MyBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        IUserService _userService;
        ICategoryService _categoryService;
        IPostService _postService;
        public HomeController(IUserService userService, ICategoryService categoryService, IPostService postService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            var posts = _postService.GetPosts();

            var vm = new HomeIndexViewModel
            {
                Categories = categories,
                Posts = posts
            };

            return View(vm);
        }

        public IActionResult Deneme()
        {
            // test amaçlı yapıldı silinecek
            //var connectionString = _configuration.GetConnectionString("MyBlogContext");
            //ViewBag.str = connectionString;
            //var options = new DbContextOptionsBuilder<MyBlogContext>()
            //    .UseSqlServer(connectionString).Options;

            //MyBlogContext db = new MyBlogContext(options);
            //UnitOfWork<MyBlogContext> uow = new UnitOfWork<MyBlogContext>(db);
            //UserService userService = new UserService(uow);

            return View(_userService.GetAllUsers());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
