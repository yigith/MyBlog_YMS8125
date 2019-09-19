using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    // https://docs.microsoft.com/tr-tr/aspnet/core/mvc/controllers/areas?view=aspnetcore-2.2
    [Authorize]
    [Area("Admin")]
    public abstract class AdminBaseController : Controller
    {

    }
}