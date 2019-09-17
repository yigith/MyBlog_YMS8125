using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BLL.Interfaces;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;
using MyBlog.UI.ViewModels;

namespace MyBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (_userService.UserExists(model.Email))
            {
                ModelState.AddModelError("Email", "Girdiğiniz e-mail adresi kullanımda.");
            }

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    UserType = UserType.Guest
                };

                _userService.AddUser(user, model.Password);

                return RedirectToAction("Login", new { register = "success" });
            }

            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                User user = _userService.GetUserByUsername(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("Email", "Böyle bir kullanıcı bulunamadı.");
                    return View();
                }

                bool isPasswordValid = _userService.VerifyPassword(user, model.Password);

                if (!isPasswordValid)
                {
                    ModelState.AddModelError("Password", "Kullanıcı adı ve parola uyuşmuyor.");
                    return View();
                }

                // giriş bilgileri doğru, kullanıcının girişini yap
                // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-2.2
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = model.RememberMe,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    IssuedUtc = DateTimeOffset.UtcNow,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home", new { login = "success" });
                }
                else
                {
                    return Redirect(returnUrl);
                }

            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home", new { logout = "success" });
        }


    }
}