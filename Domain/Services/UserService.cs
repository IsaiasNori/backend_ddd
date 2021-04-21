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
            var hash = HashHelper.EncryptPassord(user.Password);

            var result = _repository.Get(user.Name, hash);

            if (result == null)
                throw new WebException("Usuário ou senha inválidos");

            result.Token = TokenHelper.GenerateToken(result);

            _repository.Update(result, true);

            return result;
        }
    }
}