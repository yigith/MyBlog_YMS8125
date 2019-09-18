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

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                CategoryName = "Örnek Kategori"
            });

            string sampleContent = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ut pretium elit. Praesent nec mi sit amet leo mollis venenatis. Vivamus scelerisque ipsum a nunc varius, in dictum justo lacinia. Sed sit amet dui quis nisl aliquam dictum ut ut urna. Nunc risus ante, accumsan et mattis sit amet, elementum a lorem. Quisque est ante, fermentum ac efficitur eu, bibendum non risus. Donec accumsan enim id fringilla accumsan. Mauris ligula velit, viverra ut tempus vel, ullamcorper eget nulla. Praesent commodo mauris nisi, in aliquam tortor varius sit amet. Curabitur porta venenatis nulla id pellentesque. Ut tellus erat, sodales eu fermentum at, sollicitudin in nibh.</p><p>Nullam molestie, lectus at congue interdum, odio augue faucibus magna, quis lacinia sem quam eu sem. Aenean vel finibus est. In semper semper convallis. Maecenas non tincidunt est. Suspendisse ut nulla vel est blandit bibendum a sed sem. Nam ut risus velit. Vestibulum ipsum tellus, ornare at gravida non, luctus nec turpis. Suspendisse potenti. Sed turpis libero, facilisis vitae justo et, sollicitudin lacinia massa. Nam ac ornare urna, id pulvinar ante.</p><p>Vivamus facilisis vehicula ante auctor convallis. Donec iaculis, enim vel fringilla rhoncus, dui quam congue erat, sit amet gravida tellus ligula quis mauris. Suspendisse aliquet metus nibh, non efficitur urna consequat a. Etiam efficitur quam a maximus scelerisque. Vestibulum pellentesque interdum faucibus. Suspendisse potenti. Vivamus ut dui eu tellus interdum maximus in quis eros. Aliquam molestie lacus odio, quis maximus risus cursus eget.</p>";

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 1,
                CategoryId = 1,
                Title = "Örnek Yazı 1",
                Content = sampleContent,
                AuthorId = 1
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 2,
                CategoryId = 1,
                Title = "Örnek Yazı 2",
                Content = sampleContent,
                AuthorId = 1
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}
