using MyBlog.BLL.Interfaces;
using MyBlog.Common.Security;
using MyBlog.DAL.Contexts;
using MyBlog.DAL.Repositories;
using MyBlog.DAL.UnitOfWork;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork<MyBlogContext> _unitOfWork;
        IRepository<User> _userRepository;
        public UserService(IUnitOfWork<MyBlogContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public void AddUser(User user, string password)
        {
            user.PasswordHash = HashHelper.HashPassword(password);
            _userRepository.Add(user);
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(user);
            _unitOfWork.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().OrderBy(x => x.Id).ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.Get(x => x.UserName == username);
        }

        public void UpdatePassword(int userId, string password)
        {
            User user = _userRepository.GetById(userId);
            user.PasswordHash = HashHelper.HashPassword(password);
            _unitOfWork.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User record = _userRepository.GetById(user.Id);
            record.Email = user.Email;
            record.UserType = user.UserType;
            record.UserName = user.UserName;

            _userRepository.Update(record);
            _unitOfWork.SaveChanges();
        }

        public bool UserExists(string username)
        {
            return _userRepository.GetAll().Any(x => x.UserName == username);
        }

        public bool VerifyPassword(User user, string password)
        {
            return HashHelper.VerifyHashedPassword(user.PasswordHash, password);
        }
    }
}
