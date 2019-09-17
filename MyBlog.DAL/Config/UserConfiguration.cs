using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DAL.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.PasswordHash)
                .IsRequired();
        }
    }
}