using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.BLL.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
    }
}
