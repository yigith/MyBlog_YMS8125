using Microsoft.EntityFrameworkCore;
using MyBlog.DAL.Repositories;
using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.DAL.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        TContext DbContext { get;  }

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();
    }
}
