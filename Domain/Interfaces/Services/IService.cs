using System;
using Domain.Models;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IService<M>
        where M : BaseModel
    {
        List<M> Get(Int32? page, Int32? size);
        M Get(String id);
        M Create(M model, String actor);
        M Update(M model, String actor);
        void Remove(M model, String actor);
    }

}