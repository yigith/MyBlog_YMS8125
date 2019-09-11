using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBlog.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}
