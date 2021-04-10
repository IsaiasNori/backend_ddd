using System;
using System.Collections.Generic;
using Domain.Models;
using Domain.Utils;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<M> where M : BaseModel
    {
        List<M> Get();
        PagedList<M> Get(Int32 page, Int32 size);
        M Get(String id);
        String Insert(M model, Boolean commit = false);
        List<String> Insert(List<M> models, Boolean commit = false);
        void Update(M model, Boolean commit = false);
        void Update(List<M> models, Boolean commit = false);
    }

}