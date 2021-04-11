using System;
using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IService<UserModel>
    {
        UserModel Authenticate(UserModel model);
    }
}