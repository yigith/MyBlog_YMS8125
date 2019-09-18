using MyBlog.BLL.Interfaces;
using MyBlog.DAL.Contexts;
using MyBlog.DAL.Repositories;
using MyBlog.DAL.UnitOfWork;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork<MyBlogContext> _unitOfWork;
        IRepository<Category> _categoryRepository;

        public CategoryService(IUnitOfWork<MyBlogContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = _unitOfWork.GetRepository<Category>();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository
                .GetAll()
                .OrderBy(x => x.CategoryName)
                .ToList();
        }
    }
}
