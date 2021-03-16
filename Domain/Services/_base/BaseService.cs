using System;
using System.Collections.Generic;
using Domain.Core.Models;
using Domain.Core.Repositories;

namespace Domain.Core.Services
{
    public class BaseService<M> : IService<M> where M : BaseModel
    {
        protected readonly IRepository<M> _repository;
        public BaseService(IRepository<M> repository)
        {
            _repository = repository;
        }

        public List<M> Get()
        {
            return _repository.Get();
        }
        public M Get(String id)
        {
            return _repository.Get(id);
        }
        public M Create(M model)
        {
            return _repository.Insert(model, true);
        }
        public M Update(M model)
        {
            return _repository.Update(model, true);
        }
        public M SoftDelete(M model)
        {
            return _repository.SoftDelete(model, true);
        }

    }

}