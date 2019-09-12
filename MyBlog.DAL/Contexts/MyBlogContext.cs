using Microsoft.EntityFrameworkCore;
using MyBlog.Common.Security;
using MyBlog.DAL.Config;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DAL.Contexts
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            // Veritabanının oluşturulduğundan ve güncel olduğundan emin ol
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "yigith1@gmail.com",
                Email = "yigith1@gmail.com",
                PasswordHash = HashHelper.HashPassword("Ankara1."),
                UserType = UserType.Admin
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
