using System;
using System.Collections.Generic;
using Domain.Core.Models;

namespace Domain.Core.Repositories
{
    public interface IRepository<M> where M : BaseModel
    {
        List<M> Get();
        M Get(String id);
        M Insert(M model, Boolean commit = false);
        M Update(M model, Boolean commit = false);
        M SoftDelete(M model, Boolean commit = false);
    }

}