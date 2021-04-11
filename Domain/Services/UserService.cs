using System;
using System.Net;
using Domain.Core.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Utils.Helpers;

namespace Domain.Services
{
    public class UserService : BaseService<UserModel, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public UserModel Authenticate(UserModel user)
        {
            var result = _repository.Get(user.Name, user.Password);

            if (result == null)
                throw new WebException("Usuário ou senha inválidos");

            result.Token = TokenHelper.GenerateToken(result);

            _repository.Update(result, true);

            result.Password = "";

            return result;
        }
    }
}