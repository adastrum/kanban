using System;
using System.Collections.Generic;
using Kanban.Domain.Services.Repositories;
using Kanban.Domain.Services.Services;
using Kanban.SharedKernel;

namespace Kanban.Application.Services
{
    public abstract class ApplicationServiceBase<TEntity> : ICrudService<TEntity>, IFilterable<TEntity>
        where TEntity: Entity
    {
        private readonly IRepository<TEntity> _repository;

        protected ApplicationServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Create(TEntity item)
        {
            _repository.Create(item);
        }

        public TEntity FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public void Remove(TEntity item)
        {
            _repository.Remove(item);
        }

        public void Update(TEntity item)
        {
            _repository.Update(item);
        }

        public IEnumerable<TEntity> Get(IFilter<TEntity> filter)
        {
            return _repository.Get(filter.GetExpression());
        }
    }
}
