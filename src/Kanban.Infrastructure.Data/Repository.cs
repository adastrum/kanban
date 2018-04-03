using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kanban.Domain.Services.Repositories;
using Kanban.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }

        public TEntity FindById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
