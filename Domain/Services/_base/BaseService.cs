using System;
using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Core.Services
{
    public class BaseService<M, R> : IService<M>
        where M : BaseModel
        where R : IRepository<M>
    {
        protected readonly R _repository;
        public BaseService(R repository) => _repository = repository;


        public List<M> Get(Int32? page, Int32? size)
        {
            return _repository.Get();
        }
        public M Get(String id)
        {
            return _repository.Get(id);
        }
        public M Create(M model, String actor)
        {
            var id = _repository.Insert(model, true);
            return model;
        }
        public M Update(M model, String actor)
        {
            _repository.Update(model, true);
            return model;
        }
        public void Remove(M model, String actor)
        {
            _repository.Update(model, true);
        }

    }

}