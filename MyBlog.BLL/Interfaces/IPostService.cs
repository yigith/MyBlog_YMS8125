using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.BLL.Interfaces
{
    public interface IPostService
    {
        void AddPost(Post post);
        List<Post> GetPosts();
    }
}
