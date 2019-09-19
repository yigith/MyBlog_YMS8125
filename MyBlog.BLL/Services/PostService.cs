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
    public class PostService : IPostService
    {
        IUnitOfWork<MyBlogContext> _unitOfWork;
        IRepository<Post> _postRepository;

        public PostService(IUnitOfWork<MyBlogContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _postRepository = _unitOfWork.GetRepository<Post>();
        }

        public void AddPost(Post post)
        {
            _postRepository.Add(post);
            _unitOfWork.SaveChanges();
        }

        public List<Post> GetPosts()
        {
            return _postRepository
                .GetAll()
                .OrderBy(x => x.Id)
                .ToList();
        }
    }
}
