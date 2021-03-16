using Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Domain.Core.Services
{
    public interface IService<M> where M : BaseModel
    {
        public List<M> Get();
        public M Get(String id);
        public M Create(M model);
        public M Update(M model);
        public M SoftDelete(M model);
    }

}