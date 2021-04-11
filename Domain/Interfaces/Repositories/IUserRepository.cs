using System;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
        UserModel Get(String name, String password);
    }

}