using Microsoft.EntityFrameworkCore;
using MyBlog.DAL.Config;
using MyBlog.Domain.Entities;
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
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
